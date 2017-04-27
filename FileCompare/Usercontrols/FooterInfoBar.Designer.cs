namespace FileCompare
{
    partial class FooterInfoBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFooterInfo = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.lblLeftFileSize = new System.Windows.Forms.Label();
            this.lblRightFileSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFooterInfo
            // 
            this.labelFooterInfo.AutoSize = true;
            this.labelFooterInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFooterInfo.Location = new System.Drawing.Point(0, 0);
            this.labelFooterInfo.Name = "labelFooterInfo";
            this.labelFooterInfo.Size = new System.Drawing.Size(0, 13);
            this.labelFooterInfo.TabIndex = 0;
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCompare.Location = new System.Drawing.Point(560, 3);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 42);
            this.btnCompare.TabIndex = 1;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // lblLeftFileSize
            // 
            this.lblLeftFileSize.AutoSize = true;
            this.lblLeftFileSize.Location = new System.Drawing.Point(3, 3);
            this.lblLeftFileSize.Name = "lblLeftFileSize";
            this.lblLeftFileSize.Size = new System.Drawing.Size(0, 13);
            this.lblLeftFileSize.TabIndex = 2;
            // 
            // lblRightFileSize
            // 
            this.lblRightFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRightFileSize.AutoSize = true;
            this.lblRightFileSize.Location = new System.Drawing.Point(1180, 4);
            this.lblRightFileSize.Name = "lblRightFileSize";
            this.lblRightFileSize.Size = new System.Drawing.Size(0, 13);
            this.lblRightFileSize.TabIndex = 3;
            // 
            // FooterInfoBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.lblRightFileSize);
            this.Controls.Add(this.lblLeftFileSize);
            this.Controls.Add(this.labelFooterInfo);
            this.Name = "FooterInfoBar";
            this.Size = new System.Drawing.Size(1218, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFooterInfo;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblLeftFileSize;
        private System.Windows.Forms.Label lblRightFileSize;
    }
}
