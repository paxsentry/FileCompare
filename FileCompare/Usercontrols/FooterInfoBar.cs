using System.Windows.Forms;
using FileCompare.Interfaces;
using FileCompare.Presenters;
using NLog;

namespace FileCompare
{
    public partial class FooterInfoBar : UserControl, IFooterView
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public FooterInfoBar()
        {
            InitializeComponent();
        }

        public string LeftFileSizeLabel { set { lblLeftFileSize.Text = value; } }
        public string LeftFileModifiedDateLabel { set { lblLeftFileModDate.Text = value; } }
        public string LeftFileCreatedDateLabel { set { lblLeftFileCreateDate.Text = value; } }

        public string RightFileSizeLabel { set { lblRightFileSize.Text = value; } }
        public string RightFileModifiedDateLabel { set { lblRightFileModDate.Text = value; } }
        public string RightFileCreatedDateLabel { set { lblRightFileCreateDate.Text = value; } }

        public FooterViewPresenter Presenter { private get; set; }
    }
}