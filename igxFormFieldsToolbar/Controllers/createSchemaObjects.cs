using igxFormFieldsToolbar.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
namespace igxFormFieldsToolbar
{
	
	public partial class Controllers
	{
		public static List<IGXSchema> createSchemaObjects()
		{
			List<IGXSchema> schemas = new List<IGXSchema>(){ };
			var files = System.IO.Directory.GetFiles(@"C:\Users\jallard.INGENIUX\source\repos\igxFormFieldsToolbar\igxFormFieldsToolbar\etc\JSON Files\");
			foreach (string file in files)
			{
				string jsonFile = System.IO.File.ReadAllText(file);
				JObject input = JObject.Parse(jsonFile);

				IGXSchema newSchema = new IGXSchema()
				{
					isComponent = (bool)input["_CurrentVersion"]["IsComponent"],
					friendlyName = (string)input["Name"],
					jsonString = jsonFile
				};
				schemas.Add(newSchema);


			}
		return schemas;
		}
	}
	

}