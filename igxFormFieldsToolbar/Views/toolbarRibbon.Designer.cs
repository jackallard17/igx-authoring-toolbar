
namespace igxFormFieldsToolbar
{
    partial class igxToolbar : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public igxToolbar()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.igxAuthoringToolbar = this.Factory.CreateRibbonTab();
            this.authoringControls = this.Factory.CreateRibbonGroup();
            this.newPage = this.Factory.CreateRibbonButton();
            this.igxAuthoringToolbar.SuspendLayout();
            this.authoringControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // igxAuthoringToolbar
            // 
            this.igxAuthoringToolbar.Groups.Add(this.authoringControls);
            this.igxAuthoringToolbar.Label = "IGX Authoring Toolbar";
            this.igxAuthoringToolbar.Name = "igxAuthoringToolbar";
            // 
            // authoringControls
            // 
            this.authoringControls.Items.Add(this.newPage);
            this.authoringControls.Label = "Authoring Controls";
            this.authoringControls.Name = "authoringControls";
            // 
            // newPage
            // 
            this.newPage.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.newPage.Label = "Add New CMS Page";
            this.newPage.Name = "newPage";
            this.newPage.OfficeImageId = "FileNew";
            this.newPage.ShowImage = true;
            this.newPage.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.newPage_Click_1);
            // 
            // igxToolbar
            // 
            this.Name = "igxToolbar";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.igxAuthoringToolbar);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.toolbarRibbon_Load);
            this.igxAuthoringToolbar.ResumeLayout(false);
            this.igxAuthoringToolbar.PerformLayout();
            this.authoringControls.ResumeLayout(false);
            this.authoringControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab igxAuthoringToolbar;

        internal Microsoft.Office.Tools.Ribbon.RibbonGroup authoringControls;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton newPage;
    }

    partial class ThisRibbonCollection
    {
        internal igxToolbar toolbarRibbon
        {
            get { return this.GetRibbon<igxToolbar>(); }
        }
    }
}
