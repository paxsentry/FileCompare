namespace FileCompare.Usercontrols
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
            // FooterInfoBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelFooterInfo);
            this.Name = "FooterInfoBar";
            this.Size = new System.Drawing.Size(1218, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFooterInfo;
    }
}
