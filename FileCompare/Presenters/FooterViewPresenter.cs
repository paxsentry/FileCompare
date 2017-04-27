using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompare.Presenters
{
    public class FooterViewPresenter
    {
        public FooterViewPresenter()
        {

        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jipppiiii!!!!");
            //UserControl LeftPanel = (this.Parent as MainForm).Controls["SplitContainer"] as UserControl;
            //UserControl RightPanel = (this.Parent as MainForm).Controls["RightPanel"] as UserControl;

            //if (LeftPanel != null && RightPanel != null)
            //{
            //    MessageBox.Show("Jipppiiii!!!!");
            //}
        }
    }
}