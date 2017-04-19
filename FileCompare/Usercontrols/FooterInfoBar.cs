using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompare.Usercontrols
{
    public partial class FooterInfoBar : UserControl
    {
        public FooterInfoBar()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            UserControl LeftPanel = (this.Parent as MainForm).Controls["SplitContainer"] as UserControl;
            UserControl RightPanel = (this.Parent as MainForm).Controls["RightPanel"] as UserControl;

            if(LeftPanel != null && RightPanel != null)
            {
                MessageBox.Show("Jipppiiii!!!!");
            }
        }
    }
}
