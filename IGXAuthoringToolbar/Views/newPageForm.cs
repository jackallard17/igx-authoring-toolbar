using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IGXAuthoringToolbar.SchemaDesignerService;
using IGXAuthoringToolbar.Controllers;

namespace IGXAuthoringToolbar
{
    public partial class newPageForm : Form
    {
        List<SchemaDetails> schemas = SchemaImportController.getSchemaDetails(UserAuthController.currentUser);
        DocumentController documentControls = new DocumentController();

        public newPageForm()
        {
            InitializeComponent();
            schemas = SchemaImportController.getSchemaDetails(UserAuthController.currentUser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userSelection = schemasListBox.SelectedIndex;
            if (userSelection != -1)
            {
                documentControls.addCMSPage(schemas, userSelection);
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

            schemasListBox.BeginUpdate();
            foreach (SchemaDetails schema in schemas){
                schemasListBox.Items.Add(schema.FriendlyName);
            }
            schemasListBox.EndUpdate();

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            schemasListBox.Items.Clear();

            schemasListBox.BeginUpdate();
            foreach (SchemaDetails schema in schemas)
            {
                if (schema.FriendlyName.StartsWith(schemaFilterSearchBox.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    schemasListBox.Items.Add(schema.FriendlyName);
                }
            }
            schemasListBox.EndUpdate();
            

        }
    }
}
