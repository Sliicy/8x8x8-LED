using CommandLine;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _8x8x8_LED
{
    public static class Program
    {
        public class Options
        {
            [Option('o', "open", Required = false, HelpText = "Open an app automatically.")]
            public string AutoOpen { get; set; }
            [Option('m', "minimized", Required = false, HelpText = "Minimize on launch.")]
            public bool Minimized { get; set; }
            [Option('s', "single", Required = false, HelpText = "Allow only single-instance of app.")]
            public bool SingleInstance { get; set; }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string autoOpen = "";
            bool minimized = false;
            bool singleInstance = false;

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                   {
                       if (o.AutoOpen != null)
                           autoOpen = o.AutoOpen;
                       minimized = o.Minimized;
                       singleInstance = o.SingleInstance;
                   });

            // Allow only one instance of program if specified:
            if (GetPriorProcess() != null && singleInstance)
            {
                Debug.WriteLine("Only a single instance can run at a time since -s was provided as an argument!");
                return;
            }
            Application.Run(new FrmMainMenu(autoOpen, minimized));
        }

        /// <summary>
        /// Method to retrieve any prior <see cref="Process"/> identical to current one.
        /// </summary>
        /// <returns><see cref="Process"/> that was already running prior to this one.</returns>
        private static Process GetPriorProcess()
        {
            Process current = Process.GetCurrentProcess();
            Process[] prosesses = Process.GetProcessesByName(current.ProcessName);
            foreach (Process p in prosesses)
            {
                if (p.Id != current.Id && p.MainModule.FileName == current.MainModule.FileName)
                    return p;
            }
            return null;
        }
    }
}
