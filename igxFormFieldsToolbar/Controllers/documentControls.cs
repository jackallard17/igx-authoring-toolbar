using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using igxFormFieldsToolbar.Models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace igxFormFieldsToolbar
{
    public partial class Controllers
    {
        public static Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
        public static void GenerateInputFields(List<IGXSchema> schemas, int selection) //IGXSchema schema
        {
            if (selection != -1){
                //generate all field objects for the selected schema
                IGXSchema selectedSchema = schemas[selection];
                string selectedJSON = schemas[selection].jsonString;
                var jObj = JObject.Parse(selectedJSON);
                var fields = jObj["_CurrentVersion"]["_Fields"]
                    .ToObject<List<SchemaField>>();

                foreach (SchemaField field in fields)
                {
                    Debug.WriteLine("this is a field");
                }
            } else
            {
                //do nothing
            }

        }

        public static void addField(string label)
        {
            
            
        }
            

        }

        
}

//string fieldLabel = "field";
//int fieldNumber = 1;
//document.Controls.AddPlainTextContentControl($"{fieldLabel}{ fieldNumber}");
//fieldNumber++;

//var jObj = JObject.Parse(selectedJSON);
//var fields = jObj["_CurrentVersion"]["_Fields"]
//    .ToObject<List<SchemaField>>();