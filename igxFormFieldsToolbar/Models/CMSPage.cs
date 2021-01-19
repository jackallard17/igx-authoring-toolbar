using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using igxFormFieldsToolbar.SchemaDesignerService;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;



namespace igxFormFieldsToolbar.Models
{
    public class CMSPage
    {
        public Office.CustomXMLPart xmlDoc { get; set; }
        public Office.CustomXMLNode root { get; set; }

        public List<ContentControl> contentControls = new List<ContentControl>();
    }
}
