using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using igxFormFieldsToolbar.SchemaDesignerService;


using System.Diagnostics;

namespace igxFormFieldsToolbar
{
    public partial class newPageForm : Form
    {

        public List<SchemaDetails> schemas = new List<SchemaDetails>();
        public List<String> items;

        public newPageForm()
        {
            UserAuthInput testInput = new UserAuthInput()
            {
                username = "jallard",
                password = "jallard",
                membershipProvier = "IngeniuxMembershipProvider"
            };


            InitializeComponent();
            schemas = SchemaImport.getSchemaDetails(testInput);
            items = SchemaImport.returnPageNames(schemas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userSelection = listBox1.SelectedIndex;
            if (userSelection != -1)
            {
                DocumentControls.GenerateInputFields(schemas, userSelection);
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
