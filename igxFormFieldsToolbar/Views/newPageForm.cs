using System;
using System.Collections.Generic;
using System.Windows.Forms;
using igxFormFieldsToolbar.SchemaDesignerService;

namespace igxFormFieldsToolbar
{
    public partial class newPageForm : Form
    {
        List<SchemaDetails> schemas = SchemaImportController.getSchemaDetails(testInput);
        DocumentController documentControls = new DocumentController();

        static UserAuthInput testInput = new UserAuthInput()
        {
            username = "jallard",
            password = "jallard",
            membershipProvier = "IngeniuxMembershipProvider"
        };


        public newPageForm()
        {


            InitializeComponent();
            schemas = SchemaImportController.getSchemaDetails(testInput);
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
                    schemasListBox.Items.Add(schema);
                }
            }
            schemasListBox.EndUpdate();
            

        }
    }
}
