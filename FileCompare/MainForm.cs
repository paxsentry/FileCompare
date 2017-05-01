using System;
using System.Windows.Forms;
using FileCompare.Interfaces;

namespace FileCompare
{
    public partial class MainForm : Form, IMainFormView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public UCFileView LeftFileView { get { return ucFileViewLeft; } }
        public UCFileView RightFileView { get { return ucFileViewRight; } }
        public FooterInfoBar Footer { get { return footerInfoBar; } }

        public event EventHandler CompareButtonClicked
        {
            add { btnCompare.Click += value; }
            remove { btnCompare.Click -= value; }
        }
    }
}