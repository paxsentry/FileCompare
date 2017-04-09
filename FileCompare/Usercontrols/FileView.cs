using NLog;
using System;
using System.IO;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class UCFileView : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UCFileView()
        {
            InitializeComponent();
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich Text files|*.rtf|Simple Text files|*.txt|XML files|*.xml";
            var result = dialog.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    if (Path.GetExtension(dialog.FileName) == "*.rtf")
                    {
                        this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);
                        this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == "*.txt")
                    {
                        this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                        this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == "*.xml")
                    {
                        // TODO add xml loading and parsing functions
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during loading file. {ex.Message}");
                throw;
            }
        }
    }
}