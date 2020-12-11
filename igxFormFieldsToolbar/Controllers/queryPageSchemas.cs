using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Ingeniux.CMS;
using igxFormFieldsToolbar.Models;


namespace igxFormFieldsToolbar
{
    class CMSContentstore
    {
        static void Main(string[] args)
        {
        }

        public static List<String> pageSchemaFriendlyNames()
        {
            List<string> schemaFriendlyNames = new List<string>();

            var files = System.IO.Directory.GetFiles(@"C:\Users\jallard.INGENIUX\source\repos\igxFormFieldsToolbar\igxFormFieldsToolbar\etc\JSON Files\");
            foreach (string file in files)
            {
                string jsonFile = System.IO.File.ReadAllText(file);
                JObject input = JObject.Parse(jsonFile);

                bool isComopnent = (bool)input["_CurrentVersion"]["IsComponent"];

                if (isComopnent == false)
                {
                    IGXSchema newPage = new IGXSchema()
                    {
                        friendlyName = (string)input["Name"]
                    };
                    schemaFriendlyNames.Add(newPage.friendlyName);
                }
            }
                


            return schemaFriendlyNames;
        }

    }
}