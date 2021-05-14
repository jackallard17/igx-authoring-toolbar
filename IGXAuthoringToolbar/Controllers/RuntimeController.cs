using System.Collections.Generic;
using Office = Microsoft.Office.Core;
using IGXAuthoringToolbar.Models;
using IGXAuthoringToolbar.Views;
using Newtonsoft.Json;

namespace IGXAuthoringToolbar.Controllers
{
    //manages the session data across the plugin during runtime
    class RuntimeController
    {
        private Microsoft.Office.Tools.Word.Document document;
        private static Office.DocumentProperties docProps;
        private List<CMSPage> pages;

        public UserAuthForm activeForm { get; set; }

        public RuntimeController()
        {
        }

        //the two main interfaces of the RuntimeController class. called at document save time and document load time respectively
        public void serializeSessionData()
        {
            string json = "";
            foreach(CMSPage page in pages)
            {
                json += JsonConvert.SerializeObject(page);
            }
            docProps.Add("pages", false, Microsoft.Office.Core.MsoDocProperties.msoPropertyTypeString, json);
        }
        
    }
}
