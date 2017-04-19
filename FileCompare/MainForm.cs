using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class MainForm : Form
    {
        public UserControl LeftPanel { get { return ucFileViewLeft; } }

        public UserControl RightPanel { get { return ucFileViewRight; } }

        public MainForm()
        {
            InitializeComponent();
        }

        private void footerInfoBar1_Load(object sender, EventArgs e)
        {

        }
    }
}
