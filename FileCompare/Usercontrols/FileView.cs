using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FileCompare.Helpers;
using NLog;

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
            dialog.Filter = "XML files|*.xml|Rich Text files|*.rtf|Simple Text files|*.txt";
            var result = dialog.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    if (Path.GetExtension(dialog.FileName) == ".rtf")
                    {
                        this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);
                        this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == ".txt")
                    {
                        this.richTBFileView.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                        this.Text = dialog.FileName;
                    }
                    if (Path.GetExtension(dialog.FileName) == ".xml")
                    {
                        this.richTBFileView.Text = XMLLoader.Instance.ConvertXmlToText(dialog); ;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during loading file. {ex.Message}");
                throw;
            }
        }

        private void richTBFileView_TextChanged(object sender, EventArgs e)
        {
            //XMLLoader.Instance.ColoriseResult(this.richTBFileView.Text);
            //int index = richTBFileView.Text.IndexOf("<");
            //int length = 1;

            //richTBFileView.Select(index, length);
            //richTBFileView.SelectionColor = System.Drawing.Color.Blue;

            this.CheckKeyword("<", Color.Blue, 0);
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTBFileView.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTBFileView.SelectionStart;

                while((index= this.richTBFileView.Text.IndexOf(word ,(index+1))) != -1)
                {
                    this.richTBFileView.Select((index + startIndex), word.Length);
                    this.richTBFileView.SelectionColor = color;
                    this.richTBFileView.Select(selectStart, 0);
                    this.richTBFileView.SelectionColor = Color.Black;
                }
            }
        }
    }
}