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
    public partial class Controllers
    {
        public static List<String> returnPageNames(List<IGXSchema> schemaList)
        {
            List<string> pagesFriendlyNames = new List<string>();

            foreach (var item in schemaList)
            {
                if(item.isComponent == false)
                {
                    pagesFriendlyNames.Add(item.friendlyName);
                }

            }
            return pagesFriendlyNames;
        }

    }
}