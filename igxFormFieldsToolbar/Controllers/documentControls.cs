using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using igxFormFieldsToolbar.Models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace igxFormFieldsToolbar
{
    public partial class Controllers
    {
        public static Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
        public static void GenerateInputFields(List<IGXSchema> schemas, int selection)
        {
            if (selection != -1){
                //parses list of fields from JSON and adds each one
                IGXSchema selectedSchema = schemas[selection];
                string selectedJSON = schemas[selection].jsonString;
                var jObj = JObject.Parse(selectedJSON);
                var fields = jObj["_CurrentVersion"]["_Fields"]
                    .ToObject<List<SchemaField>>();

                foreach (SchemaField field in fields)
                {
                    addField(field.TypeName, field.Label, field.Required);
                }
            } else
            {
                //do nothing
            }

        }

        public static void addField(string typeName, string label, bool required)
        {
            //moves range each time field is added, generates text label over each field
            object i = 1;
            document.Paragraphs.First.Range.Select();
            var range = document.Range();

            range.Move(Unit: Word.WdUnits.wdParagraph, Count: ref i);
            document.Paragraphs.Add();
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
                control.Color = WdColor.wdColorGray40;
                control.LockContentControl = true;
            } else if (typeName == "XHTML Element")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlRichText, range);
                control.Color = WdColor.wdColorGray40;
                control.LockContentControl = true;
            } else if (typeName == "Checkbox")
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlCheckBox, range);
                control.Color = WdColor.wdColorGray40;
                control.LockContentControl = true;
            } else if (typeName == "Asset" || typeName.Contains("Image") == true)
            {
                control = document.ContentControls.Add(WdContentControlType.wdContentControlPicture, range);
                control.Color = WdColor.wdColorGray40;
                control.LockContentControl = true;
            }

        }


    }

        
}