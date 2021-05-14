using System.Collections.Generic;
using Microsoft.Office.Interop.Word;


namespace IGXAuthoringToolbar.Models
{
    public class CMSPage
    {
        public string ViewName { get; set; }
        
        public List<ContentControl> ContentControls = new List<ContentControl>();
    }
}
