using System;
using System.Windows.Forms;
using FileCompare.Presenters;

namespace FileCompare.Interfaces
{
    public interface IFooterView
    {
        string LeftFileSizeLabel { set; }
        string LeftFileModifiedDateLabel { set; }
        string LeftFileCreatedDateLabel { set; }

        string RightFileSizeLabel { set; }
        string RightFileModifiedDateLabel { set; }
        string RightFileCreatedDateLabel { set; }

        FooterViewPresenter Presenter { set; }

        Button CompareButton { get; }

        event EventHandler CompareButtonClick;
    }
}
