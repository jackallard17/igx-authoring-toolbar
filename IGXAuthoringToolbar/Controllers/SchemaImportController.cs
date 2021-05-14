using System.Collections.Generic;
using System.ServiceModel;
using IGXAuthoringToolbar.MembershipService;
using IGXAuthoringToolbar.SchemaDesignerService;
using System.ServiceModel.Channels;

namespace IGXAuthoringToolbar
{
	public class SchemaImportController
	{
		public static List<SchemaDetails> getSchemaDetails(UserAuthInput authInput)
        {
			string cmsURL = "bdsandbox";
			WSHttpBinding httpBinding = new WSHttpBinding(SecurityMode.None);
			EndpointAddress endpoint = new EndpointAddress($"http://{cmsURL}/soap/MembershipProvidersServices.svc");
			httpBinding.MaxReceivedMessageSize = 2147483647;

			string token = string.Empty;
			using (MembershipProvidersServicesClient mservice = new MembershipProvidersServicesClient(httpBinding, endpoint))
			{
				token = mservice.Login(authInput.username, authInput.password, authInput.membershipProvier).message;
			}

			endpoint = new EndpointAddress($"http://{cmsURL}/soap/SchemaDesignerServices.svc");

			List<SchemaDetails> schemasList = new List<SchemaDetails>();

			List<int> schemasToRetreive = new List<int> { 48, 95, 546 };

			foreach (int i in schemasToRetreive)
            {
				using (SchemaDesignerServicesClient service = new SchemaDesignerServicesClient(httpBinding, endpoint))
				{
					using (OperationContextScope scope = new OperationContextScope(service.InnerChannel))
					{
						OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IGXAToken", "IGXNameSpace", token));
						SchemaDetailGetInput schemaDetail = new SchemaDetailGetInput();

						schemaDetail.schemaId = $"schemas/{i}";
						schemasList.Add(service.GetSchemaDetails(schemaDetail).message);
					}
				}
			}
			return schemasList;
		}
	}
}
