using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DoaNotaPR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var thisID = Process.GetCurrentProcess().Id;
                foreach (var process in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName))
                {
                    if(process.Id != thisID)
                        process.Kill();
                }
                var exeName = Assembly.GetEntryAssembly().GetName().Name;

                if (File.Exists($"{exeName}.bak"))
                    File.Delete($"{exeName}.bak");
            }
            catch(Exception e)
            {
                new ExceptionFileHandler().CreateCrashFile(e.ToString());
            }

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new Form1());
        }

        private static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            new ExceptionFileHandler().CreateCrashFile(e.ToString());
            MessageBox.Show("Houve um erro inesperado. Por favor reinicie o sistema.");
        }
    }
}
