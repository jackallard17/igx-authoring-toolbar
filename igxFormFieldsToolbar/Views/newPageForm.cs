using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using igxFormFieldsToolbar.Models;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

using System.Diagnostics;

namespace igxFormFieldsToolbar
{
    public partial class newPageForm : Form
    {

        public List<IGXSchema> schemas = new List<IGXSchema>();
        public List<String> items;

        public newPageForm()
        {
            InitializeComponent();
            schemas = Controllers.createSchemaObjects();
            items = Controllers.returnPageNames(schemas);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userSelection = listBox1.SelectedIndex;
            if (userSelection != -1)
            {
                Controllers.GenerateInputFields(schemas, userSelection);
                this.Close();
            } 

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newPageForm_Load(object sender, EventArgs e)
        {

            listBox1.BeginUpdate();
            foreach (String schema in items){
                listBox1.Items.Add(schema);
            }
            listBox1.EndUpdate();

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            listBox1.BeginUpdate();
            foreach (String schema in items)
            {
                if (schema.StartsWith(searchBox.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBox1.Items.Add(schema);
                }
            }
            listBox1.EndUpdate();
            

        }
    }
}
