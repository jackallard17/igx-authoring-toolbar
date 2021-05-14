using IGXAuthoringToolbar.Controllers;
using IGXAuthoringToolbar.Views;
using Microsoft.Office.Tools.Ribbon;

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
            ThisAddIn.runtimeController.activeForm.ShowDialog();
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
