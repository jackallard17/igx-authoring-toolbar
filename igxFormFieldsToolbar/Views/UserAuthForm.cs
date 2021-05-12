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
        public UserAuthForm()
        {
            InitializeComponent();
        }

        private void UserAuthForm_Load(object sender, EventArgs e)
        {
            membershipProviderCombo.Items.AddRange(UserAuthController.getMembershipProviders().ToArray());
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

        private void button1_Click(object sender, EventArgs e)
        {
            UserAuthInput input = new UserAuthInput()
            {
                username = usernameTextBox.Text,
                password = passwordTextBox.Text,
                membershipProvier = membershipProviderCombo.Text
            };

            //sets current user
            UserAuthController.currentUser = input;
        }
    }
}
