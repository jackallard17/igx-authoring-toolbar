using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace igxFormFieldsToolbar
{
    public class DocumentControls
    {
        public static Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
        public static List<ContentControl> documentContentControls = new List<ContentControl>();
        public static void GenerateInputFields(List<IGXSchema> schemas, int selection)
        {
            if (selection != -1){
                //parses list of fields from JSON and adds each one
                IGXSchema selectedSchema = schemas[selection];
                string selectedJSON = schemas[selection].JsonString;
                var jObj = JObject.Parse(selectedJSON);
                var fields = jObj["_CurrentVersion"]["_Fields"]
                    .ToObject<List<SchemaField>>();

                foreach (SchemaField field in fields)
                {
                    addField(field.TypeName, field.Name, field.Label, field.Required);
                    
                }
            } else
            {
                //do nothing
            }

        }

        public static void addField(string typeName, string name, string label, bool required)
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

            range.Text = label;

            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
            document.Paragraphs.Add();
            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);

            ContentControl control;

            //mapping CMS fields to word ContentControl fields
            //using the typename string is def not the best way to do this....should probably create some kind of list/dictionary for all "_FieldTypeValue" in the JSON
            if (typeName == "Text Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlText, range);
                control.LockContentControl = true;
                control.Tag = $"{name}";
                documentContentControls.Add(control);
            }
            else if (typeName == "XHTML Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlRichText, range);
                control.LockContentControl = true;
                control.Tag = $"{name}";
                documentContentControls.Add(control);
            }
            else if (typeName == "Checkbox")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlCheckBox, range);
                control.LockContentControl = true;
                control.Tag = $"{name}";
                documentContentControls.Add(control);
            }
            else if (typeName == "Asset" || typeName.Contains("Image") == true)
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlPicture, range);
                control.LockContentControl = true;
                control.Tag = $"{name}";
                documentContentControls.Add(control);
            } else if (typeName == "List")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlBuildingBlockGallery, range);
                control.LockContentControl = true;
                control.Tag = $"{name}";
                documentContentControls.Add(control);
            }
        }

        public static void exportFieldContents()
        {
            ContentControls contentControls = document.ContentControls;
            var xmlDoc = document.CustomXMLParts.Add("<?xml version=\"1.0\" ?><content></content>");
            var root = xmlDoc.SelectSingleNode("/content");

            for (int i = 1; i < contentControls.Count + 1; i++)
            {
                string name = contentControls[i].Tag;

                if (contentControls[i].Type == WdContentControlType.wdContentControlText || contentControls[i].Type == WdContentControlType.wdContentControlRichText)
                {
                    string inputText = contentControls[i].Range.Text;

                    if (contentControls[i].ShowingPlaceholderText == false)
                    {
                        Debug.WriteLine($"<{name}>{inputText}</{ name}>");
                        xmlDoc.AddNode(root, name, null, null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, inputText);
                    }

                } else if (contentControls[i].Type == WdContentControlType.wdContentControlCheckBox)
                {
                    string isChecked = contentControls[i].Checked.ToString();

                    Debug.WriteLine($"<{name}>{isChecked}</{ name}>");
                    xmlDoc.AddNode(root, name, null, null, Office.MsoCustomXMLNodeType.msoCustomXMLNodeElement, isChecked);
                } 
            }
            System.Windows.Forms.MessageBox.Show("XML Export Complete");
        }

    }

        
}