using Microsoft.Office.Tools.Ribbon;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IGXAuthoringToolbar.Views;
using IGXAuthoringToolbar.Controllers;
using System.Windows.Forms;

namespace IGXAuthoringToolbar
{
    public partial class igxToolbar
    {
        private void toolbarRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void newPage_Click_1(object sender, RibbonControlEventArgs e)
        {
            var authResponse = UserAuthController.checkUserAuth<newPageForm>();

            if (authResponse != default)
            {
                authResponse.ShowDialog();
            }

        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            UserAuthForm form = new UserAuthForm();
            form.ShowDialog();
        }

        private void existingPage_Click(object sender, RibbonControlEventArgs e)
        {
            var authResponse = UserAuthController.checkUserAuth<ExistingPageForm>();

            if (authResponse != default)
            {
                authResponse.ShowDialog();
            }
        }
    }
}
