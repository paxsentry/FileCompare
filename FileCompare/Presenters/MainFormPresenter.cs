namespace FileCompare.Presenters
{
    class MainFormPresenter
    {
        private readonly UCFileView _leftFileView;
        private readonly UCFileView _rightFileView;
        private readonly FooterInfoBar _footer;

        public MainFormPresenter(MainForm mainFormView)
        {
            _leftFileView = mainFormView.LeftFileView;
            _rightFileView = mainFormView.RightFileView;
            _footer = mainFormView.Footer;
        }
    }
}