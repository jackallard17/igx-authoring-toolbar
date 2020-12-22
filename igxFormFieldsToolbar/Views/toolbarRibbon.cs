using Microsoft.Office.Tools.Ribbon;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            DocumentControls.exportFieldContents();
        }
    }
}
