using System.Collections.Generic;
using Office = Microsoft.Office.Core;
using IGXAuthoringToolbar.Models;
using Newtonsoft.Json;

namespace IGXAuthoringToolbar.Controllers
{
    //manages the persistance of user data between authoring sessions. 
    //all user data is serialized into json within the docProps of the file when a document is saved
    //at each runtime, this JSON data, if it exists, is pulled from the document and deserialized to be used by the addin again
    class RuntimeController
    {
        private Microsoft.Office.Tools.Word.Document document;
        private static Office.DocumentProperties docProps;
        private List<CMSPage> pages;

        public RuntimeController(Microsoft.Office.Tools.Word.Document doc,  List<CMSPage> pageList)
        {
            document = doc;
            pages = pageList;
            docProps = (Office.DocumentProperties)document.CustomDocumentProperties;
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
