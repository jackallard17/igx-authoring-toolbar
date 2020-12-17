using igxFormFieldsToolbar.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.ServiceModel;
using igxFormFieldsToolbar.MembershipService;
using igxFormFieldsToolbar.SchemaDesignerService;
using System.ServiceModel.Channels;

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
					IsComponent = (bool)input["_CurrentVersion"]["IsComponent"],
					FriendlyName = (string)input["Name"],
					JsonString = jsonFile
				};
				schemas.Add(newSchema);
			}

		return schemas;
		}


		public static List<string> getJSON(userAuthInput authInput)
        {
			var JsonString = new List<string>();
			string cmsURL = "bdsandbox";
;
			WSHttpBinding httpBinding = new WSHttpBinding(SecurityMode.None);
			EndpointAddress endpoint = new EndpointAddress($"http://{cmsURL}/soap/MembershipProvidersServices.svc");

			//generate authentication token to access CMS
			string token = string.Empty;
			using (MembershipProvidersServicesClient mservice = new MembershipProvidersServicesClient(httpBinding, endpoint))
            {
				token = mservice.Login(authInput.username, authInput.password, authInput.membershipProvier).message;
            }

			endpoint = new EndpointAddress($"http://{cmsURL}/soap/SchemaDesignerServices.svc");

			using(SchemaDesignerServicesClient service = new SchemaDesignerServicesClient(httpBinding, endpoint))
            {
				using(OperationContextScope scope =  new OperationContextScope(service.InnerChannel))
                {
					//sets authentication token in header of request
					OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IGXAToken", "IGXNameSpace", token));

					var pageSchemas = service.GetSchemasSimple().message.pageSchemas;

					foreach (var pageSchema in pageSchemas)
                    {
						SchemaDesignerService.SchemaDetailGetInput schemaDetail = new SchemaDetailGetInput();
						schemaDetail.schemaId = pageSchema.ID;

						var sd = service.GetSchemaDetails(schemaDetail);

						System.Diagnostics.Debug.WriteLine(sd.message.ViewName);
                    }
					

					//var response = service.GetSchemaDetails();
				}


			}

			return JsonString;
        }

	}
	

}
