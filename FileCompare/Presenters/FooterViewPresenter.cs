using System;

namespace FileCompare.Presenters
{
    public class FooterViewPresenter
    {
        private FooterInfoBar _footer;

        public FooterViewPresenter(FooterInfoBar footer)
        {
            _footer = footer;
            footer.Presenter = this;
            _footer.CompareButtonClick += btnCompare_Click;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            //UserControl LeftPanel = (this.Parent as MainForm).Controls["SplitContainer"] as UserControl;
            //UserControl RightPanel = (this.Parent as MainForm).Controls["RightPanel"] as UserControl;

            //if (LeftPanel != null && RightPanel != null)
            //{
            //    MessageBox.Show("Jipppiiii!!!!");
            //}


        }
    }
}