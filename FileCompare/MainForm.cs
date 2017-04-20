using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileCompare.Interfaces;

namespace FileCompare
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly UCFileView _leftPanel;
        private readonly UCFileView _rightPanel;

        public IFileView LeftFileView { get { return _leftPanel; } }
        public IFileView RightFileView { get { return _rightPanel; } }

        public MainForm()
        {
            InitializeComponent();
            _leftPanel = new UCFileView();
        }

        private void footerInfoBar1_Load(object sender, EventArgs e)
        {

        }
    }
}
