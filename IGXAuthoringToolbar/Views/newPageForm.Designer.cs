
namespace IGXAuthoringToolbar
{
    partial class newPageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newPageForm));
            this.newPageButton = new System.Windows.Forms.Button();
            this.schemasListBox = new System.Windows.Forms.ListBox();
            this.documentStoreBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.documentStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schemaFilterSearchBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // newPageButton
            // 
            this.newPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newPageButton.Location = new System.Drawing.Point(106, 366);
            this.newPageButton.Name = "newPageButton";
            this.newPageButton.Size = new System.Drawing.Size(104, 32);
            this.newPageButton.TabIndex = 0;
            this.newPageButton.Text = "Create New Page";
            this.newPageButton.UseVisualStyleBackColor = true;
            this.newPageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // schemasListBox
            // 
            this.schemasListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.schemasListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentStoreBindingSource1, "Database", true));
            this.schemasListBox.FormattingEnabled = true;
            this.schemasListBox.Location = new System.Drawing.Point(46, 56);
            this.schemasListBox.Name = "schemasListBox";
            this.schemasListBox.Size = new System.Drawing.Size(229, 303);
            this.schemasListBox.TabIndex = 3;
            this.schemasListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // documentStoreBindingSource1
            // 
            this.documentStoreBindingSource1.DataSource = typeof(Raven.Client.Documents.DocumentStore);
            // 
            // documentStoreBindingSource
            // 
            this.documentStoreBindingSource.DataSource = typeof(Raven.Client.Documents.DocumentStore);
            // 
            // schemaFilterSearchBox
            // 
            this.schemaFilterSearchBox.Location = new System.Drawing.Point(46, 12);
            this.schemaFilterSearchBox.Name = "schemaFilterSearchBox";
            this.schemaFilterSearchBox.Size = new System.Drawing.Size(229, 20);
            this.schemaFilterSearchBox.TabIndex = 4;
            this.schemaFilterSearchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(139, 35);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(29, 13);
            this.filterLabel.TabIndex = 5;
            this.filterLabel.Text = "Filter";
            this.filterLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // newPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 410);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.schemaFilterSearchBox);
            this.Controls.Add(this.schemasListBox);
            this.Controls.Add(this.newPageButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 510);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "newPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New CMS Page";
            this.Load += new System.EventHandler(this.newPageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newPageButton;
        private System.Windows.Forms.ListBox schemasListBox;
        private System.Windows.Forms.BindingSource documentStoreBindingSource1;
        private System.Windows.Forms.BindingSource documentStoreBindingSource;
        private System.Windows.Forms.TextBox schemaFilterSearchBox;
        private System.Windows.Forms.Label filterLabel;
    }
}