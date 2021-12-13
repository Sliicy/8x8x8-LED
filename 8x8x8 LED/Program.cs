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
        }

        [STAThread]
        static void Main(string[] args)
        {
            // Allow only one instance of program:
            //if (PriorProcess() != null)
            //    return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string autoOpen = "";
            bool minimized = false;

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                   {

                       if (o.AutoOpen != null)
                       {
                           autoOpen = o.AutoOpen;
                       }
                       minimized = o.Minimized;
                   });

            Application.Run(new FrmMainMenu(autoOpen, minimized));
        }

        private static Process PriorProcess()
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
