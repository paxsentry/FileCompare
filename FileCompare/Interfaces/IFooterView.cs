using System;
using System.Windows.Forms;
using FileCompare.Presenters;

namespace FileCompare.Interfaces
{
    public interface IFooterView
    {
        string LeftFileSizeLabel { set; }
        string RightFileSizeLabel { set; }

        FooterViewPresenter Presenter { set; }

        Button CompareButton { get; }

        event EventHandler CompareButtonClick;
    }
}
