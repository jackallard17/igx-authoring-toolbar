using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igxFormFieldsToolbar
{
    public partial class newPageForm : Form
    {
        List<String> items = CMSContentstore.pageSchemaFriendlyNames();

        public newPageForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
