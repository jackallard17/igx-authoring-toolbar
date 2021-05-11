using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using igxFormFieldsToolbar.Controllers;

namespace igxFormFieldsToolbar.Views
{
    public partial class UserAuthForm : Form
    {
        static UserAuthInput testInput = new UserAuthInput()
        {
            username = "jallard",
            password = "jallard",
            membershipProvier = "IngeniuxMembershipProvider"
        };

        public UserAuthForm()
        {
            InitializeComponent();
        }

        private void UserAuthForm_Load(object sender, EventArgs e)
        {
            membershipProviderCombo.Items.AddRange(UserAuthController.getMembershipProviders(testInput).ToArray());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void usrPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
