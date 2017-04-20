using System;
using System.Threading;
using System.Windows.Forms;
using FileCompare.Presenters;
using NLog;

namespace FileCompare
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();
            var presenter = new MainFormPresenter(mainForm);
            Application.Run(mainForm);
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            logger.Error($"Thread level exception! Message: {e.Exception.Message}");
            MessageBox.Show("Sorry, bug happens. Please check log!", "Thread Exception");
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error($"Program level exception! Message: {((Exception)e.ExceptionObject).Message}");
            MessageBox.Show("Sorry, bug happens. Please check log!", "Domain Exception");
        }
    }
}