using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileCompare.Interfaces;

namespace FileCompare.Presenters
{
    class MainFormPresenter
    {
        private readonly IMainFormView _mainFormView;
        private readonly IFileView _leftFileView;
        private readonly IFileView _rightFileView;

        public MainFormPresenter(IMainFormView mainFormView)
        {
            _mainFormView = mainFormView;
            _leftFileView = mainFormView.LeftFileView;
            _rightFileView = mainFormView.RightFileView;
        }
    }
}
