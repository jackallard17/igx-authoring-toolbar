using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igxFormFieldsToolbar.Models
{
    public class IGXSchema
    {
        public bool IsComponent { get; set; }

        public string FriendlyName { get; set; }

        public List<SchemaField> Fields = new List<SchemaField>();
        public string JsonString { get; set; }
    }
}
