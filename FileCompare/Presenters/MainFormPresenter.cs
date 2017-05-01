using System;
using System.Windows.Forms;
using DiffMatchPatch;

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
            mainFormView.CompareButtonClicked += MainFormView_CompareButtonClicked;
        }

        private void MainFormView_CompareButtonClicked(object sender, System.EventArgs e)
        {
            var leftTextAreaText = _leftFileView.TextPanelControl.Text;
            var rightTextAreaText = _rightFileView.TextPanelControl.Text;

            if (!string.IsNullOrWhiteSpace(leftTextAreaText) && !string.IsNullOrWhiteSpace(rightTextAreaText))
            {
                CompareTexts(leftTextAreaText, rightTextAreaText);
            }
            else
            {
                MessageBox.Show("Please provide data in both panels.");
            }
        }

        private void CompareTexts(string leftTextAreaText, string rightTextAreaText)
        {
            var diffEngine = new diff_match_patch();
            var comapre = diffEngine.diff_main(leftTextAreaText, rightTextAreaText);
            var result = diffEngine.diff_prettyHtml(comapre);
            //var result = diffEngine.diff_text2(comapre);

            _rightFileView.TextPanelControl.Controls[0].Text = result;
            //MessageBox.Show(result);
        }
    }
}