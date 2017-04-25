namespace FileCompare.Presenters
{
    class MainFormPresenter
    {
        private readonly UCFileView _leftFileView;
        private readonly UCFileView _rightFileView;

        public MainFormPresenter(MainForm mainFormView)
        {
            _leftFileView = mainFormView.LeftFileView;
            _rightFileView = mainFormView.RightFileView;
        }
    }
}
