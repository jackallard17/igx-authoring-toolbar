using System.Collections.Generic;
using Office = Microsoft.Office.Core;
using IGXAuthoringToolbar.Models;
using IGXAuthoringToolbar.Views;
using Newtonsoft.Json;

namespace IGXAuthoringToolbar.Controllers
{
    //manages the session data across the plugin during runtime. Instantiated once per user session
    class RuntimeController
    {
        private Microsoft.Office.Tools.Word.Document document;
        private static Office.DocumentProperties docProps;
        private List<CMSPage> pages;

        public UserAuthForm activeForm { get; set; }

        public RuntimeController()
        {
        }
    }
}
