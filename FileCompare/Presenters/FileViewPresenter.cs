using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FileCompare.Helpers;
using NLog;
using ScintillaNET;

namespace FileCompare.Presenters
{
    public class FileViewPresenter
    {
        private readonly UCFileView _fileView;
        private readonly Panel ScintillaTextPanel;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        Scintilla TextArea;

        public FileViewPresenter(UCFileView fileView)
        {
            _fileView = fileView;
            fileView.Presenter = this;
            ScintillaTextPanel = _fileView.TextPanelControl;
            _fileView.Load += UCFileView_Load;
            _fileView.LoadFileClicked += toolStripButtonOpenFile_Click;
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            //   dialog.Filter = "XML files|*.xml|Rich Text files|*.rtf|Simple Text files|*.txt";
            var result = dialog.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    TextArea.Text = File.ReadAllText(dialog.FileName);
                    ScintillaSettings.SetupXML(TextArea);
                    // TODO check file type and modify scintilla settings.
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during loading file. {ex.Message}");
                throw;
            }
        }

        private void UCFileView_Load(object sender, EventArgs e)
        {
            TextArea = new Scintilla();
            ScintillaTextPanel.Controls.Add(TextArea);
            ScintillaSettings.SetupScintilla(TextArea);
        }
    }
}
