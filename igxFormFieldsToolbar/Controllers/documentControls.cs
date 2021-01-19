using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using igxFormFieldsToolbar.Models;
using igxFormFieldsToolbar.SchemaDesignerService;


namespace igxFormFieldsToolbar
{
    public class DocumentControls
    {
        public static Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
        public static List<ContentControl> documentContentControls = new List<ContentControl>();

        public List<CMSPage> xmlParts = new List<CMSPage>();
        public void addCMSPage(List<SchemaDetails> schemas, int selection)
        {
            //create a new custom XML part for the page
            var currentPageNode = schemas[selection].ViewName;

            CMSPage newPage = new CMSPage();
            newPage.xmlDoc = document.CustomXMLParts.Add($"<?xml version=\"1.0\" ?><{currentPageNode}></{currentPageNode}>");
            newPage.root = newPage.xmlDoc.SelectSingleNode($"/{currentPageNode}");
            
            if (selection != -1){
                SchemaDetails selectedSchema = schemas[selection];
                var fields = selectedSchema.Fields;

                foreach (SchemaFieldInfo field in fields)
                {
                    addField(field, newPage);
                }
            } else
            {
                //do nothing
            }
            xmlParts.Add(newPage);
        }

        public void addField(SchemaFieldInfo field, CMSPage page)
        {
            //moves range each time field is added, generates text label over each field
            object i = 1;
            document.ActiveWindow.View.ReadingLayout = false;
            document.Paragraphs.First.Range.Select();
            var range = document.Range();

            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
            document.Paragraphs.Add();
            range.set_Style(Word.WdBuiltinStyle.wdStyleStrong);
            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);

            range.Text = field.Label;

            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
            document.Paragraphs.Add();
            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);


            //mapping CMS fields to word ContentControl fields
            //using the typename string is def not the best way to do this....should probably create some kind of list/dictionary for all "_FieldTypeValue" in the JSON

            ContentControl control;

            if (field.TypeName == "Text Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlText, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.contentControls.Add(control);
            }
            else if (field.TypeName == "XHTML Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlRichText, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.contentControls.Add(control);
            }
            else if (field.TypeName == "Checkbox")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlCheckBox, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.contentControls.Add(control);
            }
            else if (field.TypeName == "Asset" || field.TypeName.Contains("Image") == true)
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlPicture, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.contentControls.Add(control);
            } else if (field.TypeName == "List")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlBuildingBlockGallery, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.contentControls.Add(control);
            }
        }
      
        public void exportFieldContents()
        {
            foreach(CMSPage page in xmlParts)
            {
                List<ContentControl> contentControls = page.contentControls;

                System.Diagnostics.Debug.WriteLine("cms page iteration");
                foreach (ContentControl control in contentControls)
                {
                    string name = control.Tag;

                    if (control.Type == WdContentControlType.wdContentControlText || control.Type == WdContentControlType.wdContentControlRichText)
                    {
                        string inputText = control.Range.Text;

                        if (control.ShowingPlaceholderText == false)
                        {
                            page.xmlDoc.AddNode(page.root, name, null, null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, inputText);
                            System.Diagnostics.Debug.WriteLine("node added");
                        }
                    }
                    else if (control.Type == WdContentControlType.wdContentControlCheckBox)
                    {
                        string isChecked = control.Checked.ToString();
                        page.xmlDoc.AddNode(page.root, name, null, null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, isChecked);
                        
                    }
                }
            }

            System.Windows.Forms.MessageBox.Show("XML Export Complete");
        }

    }
}