
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
            this.existingPage = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button2 = this.Factory.CreateRibbonButton();
            this.igxAuthoringToolbar.SuspendLayout();
            this.authoringControls.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // igxAuthoringToolbar
            // 
            this.igxAuthoringToolbar.Groups.Add(this.authoringControls);
            this.igxAuthoringToolbar.Groups.Add(this.group1);
            this.igxAuthoringToolbar.Groups.Add(this.group2);
            this.igxAuthoringToolbar.Label = "IGX Authoring Toolbar";
            this.igxAuthoringToolbar.Name = "igxAuthoringToolbar";
            // 
            // authoringControls
            // 
            this.authoringControls.Items.Add(this.newPage);
            this.authoringControls.Items.Add(this.existingPage);
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
            // existingPage
            // 
            this.existingPage.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.existingPage.Label = "Edit Existing Page";
            this.existingPage.Name = "existingPage";
            this.existingPage.OfficeImageId = "FileExcelServicesOptions";
            this.existingPage.ShowImage = true;
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            this.group1.Label = "Content Export Options";
            this.group1.Name = "group1";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Label = "Export Content to XML";
            this.button1.Name = "button1";
            this.button1.OfficeImageId = "XmlExport";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.button2);
            this.group2.Label = "IGX Account";
            this.group2.Name = "group2";
            // 
            // button2
            // 
            this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button2.Label = "My Account";
            this.button2.Name = "button2";
            this.button2.OfficeImageId = "AccountMenu";
            this.button2.ShowImage = true;
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
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab igxAuthoringToolbar;

        internal Microsoft.Office.Tools.Ribbon.RibbonGroup authoringControls;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton newPage;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton existingPage;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
    }

    partial class ThisRibbonCollection
    {
        internal igxToolbar toolbarRibbon
        {
            get { return this.GetRibbon<igxToolbar>(); }
        }
    }
}
