using System;
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
        private readonly FooterInfoBar _footer;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        Scintilla TextArea;

        public FileViewPresenter(UCFileView fileView, FooterInfoBar footer)
        {
            _fileView = fileView;
            _footer = footer;
            fileView.Presenter = this;
            ScintillaTextPanel = _fileView.TextPanelControl;
            _fileView.Load += UCFileView_Load;
            _fileView.LoadFileClicked += toolStripButtonOpenFile_Click;
        }

        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            var leftOrRight = ((ToolStripButton)sender).Name;
            //   dialog.Filter = "XML files|*.xml|Rich Text files|*.rtf|Simple Text files|*.txt";
            var result = dialog.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    TextArea.Text = File.ReadAllText(dialog.FileName);
                    SetFilePathAndName(dialog.FileName);
                    ScintillaSettings.SetupXML(TextArea);

                    FileInfo f = new FileInfo(dialog.FileName);

                    _footer.LeftFileSizeLabel = HelperFunctions.BytesToString(f.Length);
                    // TODO if (Path.GetExtension(dialog.FileName) == ".rtf") { }
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

        private void SetFilePathAndName(string filePathAndName)
        {
            _fileView.FileNameAndPath = filePathAndName;
        }


    }
}
