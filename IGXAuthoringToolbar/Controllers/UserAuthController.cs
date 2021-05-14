using IGXAuthoringToolbar.MembershipService;
using IGXAuthoringToolbar.Views;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace IGXAuthoringToolbar.Controllers
{
    class UserAuthController
    {
        public static UserAuthInput currentUser { get; set; }

        public static T checkUserAuth<T>() where T : new()
        {
            if (currentUser == null)
            {
                ThisAddIn.runtimeController.activeForm.ShowDialog();

                return default;
            } else
            {
                return new T();
            }
        }

        public static List<string> getMembershipProviders()
        {
            List<string> membershipProviders = new List<string>();

            string cmsURL = "bdsandbox";
            WSHttpBinding httpBinding = new WSHttpBinding(SecurityMode.None);
            EndpointAddress endpoint = new EndpointAddress($"http://{cmsURL}/soap/MembershipProvidersServices.svc");
            httpBinding.MaxReceivedMessageSize = 2147483647;

            using (MembershipProvidersServicesClient mservice = new MembershipProvidersServicesClient(httpBinding, endpoint))
            {
                var response = mservice.GetMembershipProviders().message.Providers.ToArray();
                
                foreach (KeyValuePairOfstringMembershipProviderChoiceO5HAFep4 provider in response)
                {
                    membershipProviders.Add(provider.value.displayName);
                }
            }
            return membershipProviders;
        }
    }
}
