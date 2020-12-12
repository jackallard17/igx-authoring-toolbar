using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igxFormFieldsToolbar.Models
{
    public class IGXSchema
    {
        public bool isComponent { get; set; }

        public string friendlyName { get; set; }

        public List<SchemaField> Fields = new List<SchemaField>();
        public string jsonString { get; set; }
    }
}
