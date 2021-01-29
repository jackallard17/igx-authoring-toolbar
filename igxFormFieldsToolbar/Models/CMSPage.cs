using System.Collections.Generic;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json.Linq;


namespace igxFormFieldsToolbar.Models
{
    public class CMSPage
    {
        public string ViewName { get; set; }
        
        public List<ContentControl> ContentControls = new List<ContentControl>();
    }
}
