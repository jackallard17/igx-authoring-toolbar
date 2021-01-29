using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using igxFormFieldsToolbar.Models;
using igxFormFieldsToolbar.SchemaDesignerService;
using System.Diagnostics;

namespace igxFormFieldsToolbar
{
    public class DocumentController
    {
        public static Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);

        public static List<CMSPage> pages = new List<CMSPage>();
        public void addCMSPage(List<SchemaDetails> schemas, int selection)
        {
            //Creates a new XML part corresponding to a CMS page, sets the root node
            CMSPage newPage = new CMSPage();
            newPage.ViewName = schemas[selection].ViewName;
            
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
            pages.Add(newPage);
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

            ContentControl control;

            if (field.TypeName == "Text Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlText, range);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            else if (field.TypeName == "XHTML Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlRichText, range);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            else if (field.TypeName == "Checkbox")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlCheckBox, range);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
            else if (field.TypeName == "Asset" || field.TypeName.Contains("Image") == true)
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlPicture, range);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            } else if (field.TypeName == "List")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlBuildingBlockGallery, range);
                control.LockContentControl = true;
                control.Tag = $"{field.Name}";
                page.ContentControls.Add(control);
            }
        }
      
        public void exportFieldContents()
        {
            foreach(CMSPage page in pages)
            {
                var newXMLPart = document.CustomXMLParts.Add($"<?xml version=\"1.0\" ?><{page.ViewName}></{page.ViewName}>");
                var root = newXMLPart.SelectSingleNode($"/{page.ViewName}");

                foreach (ContentControl control in page.ContentControls)
                {
                    if (control.Type == WdContentControlType.wdContentControlText || control.Type == WdContentControlType.wdContentControlRichText)
                    {
                        newXMLPart.AddNode(root, $"{control.Tag}", "", null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, $"{control.Range.Text}");
                    }
                    else if (control.Type == WdContentControlType.wdContentControlCheckBox)
                    {
                        newXMLPart.AddNode(root, $"{control.Tag}", "", null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, $"{control.Checked.ToString()}");
                    }
                }
            }
        }
    }
}