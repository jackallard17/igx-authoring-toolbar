using System.Collections.Generic;
using Microsoft.Office.Interop.Word;


namespace igxFormFieldsToolbar.Models
{
    public class CMSPage
    {
        public string ViewName { get; set; }
        
        public List<ContentControl> ContentControls = new List<ContentControl>();
    }
}
