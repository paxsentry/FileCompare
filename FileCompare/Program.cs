using System;
using System.Windows.Forms;
using FileCompare.Presenters;

namespace FileCompare
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();
            var presenter = new MainFormPresenter(mainForm);
            Application.Run(mainForm);
        }
    }
}