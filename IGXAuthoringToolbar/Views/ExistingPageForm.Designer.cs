
namespace IGXAuthoringToolbar.Views
{
    partial class ExistingPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExistingPageForm));
            this.xIDLabel = new System.Windows.Forms.Label();
            this.xIDTextBox = new System.Windows.Forms.TextBox();
            this.importPageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xIDLabel
            // 
            this.xIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xIDLabel.AutoSize = true;
            this.xIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xIDLabel.Location = new System.Drawing.Point(99, 29);
            this.xIDLabel.Name = "xIDLabel";
            this.xIDLabel.Size = new System.Drawing.Size(76, 20);
            this.xIDLabel.TabIndex = 0;
            this.xIDLabel.Text = "Enter xID";
            // 
            // xIDTextBox
            // 
            this.xIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xIDTextBox.Location = new System.Drawing.Point(78, 52);
            this.xIDTextBox.Name = "xIDTextBox";
            this.xIDTextBox.Size = new System.Drawing.Size(122, 20);
            this.xIDTextBox.TabIndex = 1;
            // 
            // importPageButton
            // 
            this.importPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importPageButton.Location = new System.Drawing.Point(91, 86);
            this.importPageButton.Name = "importPageButton";
            this.importPageButton.Size = new System.Drawing.Size(97, 52);
            this.importPageButton.TabIndex = 2;
            this.importPageButton.Text = "Import Page";
            this.importPageButton.UseVisualStyleBackColor = true;
            // 
            // ExistingPageForm
            // 
            this.AcceptButton = this.importPageButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 150);
            this.Controls.Add(this.importPageButton);
            this.Controls.Add(this.xIDTextBox);
            this.Controls.Add(this.xIDLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ExistingPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Existing Page";
            this.Load += new System.EventHandler(this.ExistingPageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xIDLabel;
        private System.Windows.Forms.TextBox xIDTextBox;
        private System.Windows.Forms.Button importPageButton;
    }
}