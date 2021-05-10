using Microsoft.Office.Tools.Ribbon;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using igxFormFieldsToolbar.Views;

namespace igxFormFieldsToolbar
{
    public partial class igxToolbar
    {
        private void toolbarRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void newPage_Click_1(object sender, RibbonControlEventArgs e)
        {
            newPageForm form = new newPageForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            UserAuthForm form = new UserAuthForm();
            form.ShowDialog();
        }

        private void existingPage_Click(object sender, RibbonControlEventArgs e)
        {
            ExistingPageForm form = new ExistingPageForm();
            form.ShowDialog();
        }
    }
}
