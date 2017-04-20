using System;
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
            _rightPanel = new UCFileView();
        }
    }
}