using System;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class UCFileView : UserControl
    {
        public UCFileView()
        {
            InitializeComponent();
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich Text files|*.rtf";
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);
                this.Text = dialog.FileName;
            }
        }
    }
}