using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Diagnostics;
using igxFormFieldsToolbar.SchemaDesignerService;


namespace igxFormFieldsToolbar
{
    public class DocumentControls
    {
        public static Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
        public static List<ContentControl> documentContentControls = new List<ContentControl>();
        public static void AddCMSPage(List<SchemaDetails> schemas, int selection)
        {
            //create a new custom XML part for the page
            var currentPageNode = schemas[selection].ViewName;
            Office.CustomXMLPart xmlDoc = document.CustomXMLParts.Add($"<?xml version=\"1.0\" ?><{currentPageNode}></{currentPageNode}>");
            Office.CustomXMLNode root = xmlDoc.SelectSingleNode($"/{currentPageNode}");

            if (selection != -1){
                SchemaDetails selectedSchema = schemas[selection];
                var fields = selectedSchema.Fields;

                foreach (SchemaFieldInfo field in fields)
                {
                    addField(field);
                }
            } else
            {
                //do nothing
            }

        }

        public static void addField(SchemaFieldInfo field)
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
            }
            else if (field.TypeName == "XHTML Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlRichText, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
            }
            else if (field.TypeName == "Checkbox")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlCheckBox, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
            }
            else if (field.TypeName == "Asset" || field.TypeName.Contains("Image") == true)
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlPicture, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
            } else if (field.TypeName == "List")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlBuildingBlockGallery, range);
                documentContentControls.Add(control);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
            }
        }
      
        public static void exportFieldContents()
        {
            ContentControls contentControls = document.ContentControls;

            for (int i = 1; i < contentControls.Count + 1; i++)
            {
                string name = contentControls[i].Tag;

                if (contentControls[i].Type == WdContentControlType.wdContentControlText || contentControls[i].Type == WdContentControlType.wdContentControlRichText)
                {
                    string inputText = contentControls[i].Range.Text;

                    if (contentControls[i].ShowingPlaceholderText == false)
                    {
                        //xmlDoc.AddNode(root, name, null, null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, inputText);
                    }
                } else if (contentControls[i].Type == WdContentControlType.wdContentControlCheckBox)
                {
                    string isChecked = contentControls[i].Checked.ToString();
                    //xmlDoc.AddNode(root, name, null, null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, isChecked);
                } 
            }
            System.Windows.Forms.MessageBox.Show("XML Export Complete");
        }

    }

        
}