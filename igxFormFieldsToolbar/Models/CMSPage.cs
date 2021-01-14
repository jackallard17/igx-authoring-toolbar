using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using igxFormFieldsToolbar.SchemaDesignerService;
using Office = Microsoft.Office.Core;



namespace igxFormFieldsToolbar.Models
{
    class CMSPage
    {
        public Office.CustomXMLPart xmlDoc { get; set; }

        public Office.CustomXMLNode root { get; set; }
    }
}
