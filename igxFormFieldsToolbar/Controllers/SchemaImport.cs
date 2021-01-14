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
	public class SchemaImport
	{
		public static UserAuthInput testInput = new UserAuthInput()
		{
			username = "jallard",
			password = "jallard",
			membershipProvier = "IngeniuxMembershipProvider"
		};

		public static List<IGXSchema> createSchemaObjects()
		{
			List<IGXSchema> schemaList = new List<IGXSchema>(){ };

			List<SchemaDetails> schema = getSchemaDetails(testInput);

			IGXSchema newSchema = new IGXSchema()
			{
				//ID = schema.UniqueID,
				//Name = schema.FriendlyName
			};

			schemaList.Add(newSchema);

		return schemaList;
		}


		public static List<SchemaDetails> getSchemaDetails(UserAuthInput authInput)
        {
			var JsonString = new List<string>();
			string cmsURL = "bdsandbox";
;
			WSHttpBinding httpBinding = new WSHttpBinding(SecurityMode.None);
			EndpointAddress endpoint = new EndpointAddress($"http://{cmsURL}/soap/MembershipProvidersServices.svc");

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
					OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IGXAToken", "IGXNameSpace", token));

					List<SchemaDetails> schemasList = new List<SchemaDetails>();
					SchemaDetailGetInput schemaID = new SchemaDetailGetInput();

					schemaID.schemaId = $"schemas/546";
					schemasList.Add(service.GetSchemaDetails(schemaID).message);

					//for (int i = 0; i < 546; i++)
					//{
					//	schemaID.schemaId = $"schemas/{i}";
					//	schemasList.Add(service.GetSchemaDetails(schemaID).message);
					//}
					return schemasList;
				}
			}
        }

		public static List<String> returnPageNames(List<SchemaDetails> schemaList)
		{
			List<string> pagesFriendlyNames = new List<string>();

			foreach (var item in schemaList)
			{
				pagesFriendlyNames.Add(item.FriendlyName);
			}
			return pagesFriendlyNames;
		}
	}
}
