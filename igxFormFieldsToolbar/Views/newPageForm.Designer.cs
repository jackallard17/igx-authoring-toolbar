
namespace igxFormFieldsToolbar
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.documentStoreBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.documentStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(106, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create New Page";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentStoreBindingSource1, "Database", true));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(46, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(229, 303);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // documentStoreBindingSource1
            // 
            this.documentStoreBindingSource1.DataSource = typeof(Raven.Client.Documents.DocumentStore);
            // 
            // documentStoreBindingSource
            // 
            this.documentStoreBindingSource.DataSource = typeof(Raven.Client.Documents.DocumentStore);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(46, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(229, 20);
            this.searchBox.TabIndex = 4;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // newPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 410);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(500, 510);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "newPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Page Schema";
            this.Load += new System.EventHandler(this.newPageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentStoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource documentStoreBindingSource1;
        private System.Windows.Forms.BindingSource documentStoreBindingSource;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label1;
    }
}