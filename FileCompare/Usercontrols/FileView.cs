using System;
using System.Windows.Forms;
using FileCompare.Interfaces;
using FileCompare.Presenters;
using NLog;

namespace FileCompare
{
    public partial class UCFileView : UserControl, IFileView
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UCFileView()
        {
            InitializeComponent();
        }

        public string FileNameAndPath { set { lblFilePathAndName.Text = value; } }

        public Panel TextPanelControl { get { return TextPanel; } }

        public FileViewPresenter Presenter { private get; set; }

        public event EventHandler LoadFileClicked
        {
            add { toolStripButtonOpenFile.Click += value; }
            remove { toolStripButtonOpenFile.Click -= value; }
        }

        public void SetFilePathAndName(string filePathAndName)
        {
            lblFilePathAndName.Text = filePathAndName;
        }
    }
}