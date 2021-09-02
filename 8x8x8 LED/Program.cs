using _8x8x8_LED.View;
using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8x8x8_LED
{
    public static class Program
    {
        public static List<string> existingApps = new List<string>() {
            "Balls",
            "Clock",
            "Image Viewer",
            "Marquee",
            "Music",
            "Phone Square",
            "Pong",
            "Rain",
            "Snake",
            "Video"};

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
            if (PriorProcess() != null)
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string autoOpen = "";
            bool minimized = false;
            
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                   {
                       
                       if (o.AutoOpen != null)
                       {
                           if (!existingApps.Contains(o.AutoOpen))
                           {
                               MessageBox.Show("Requested app doesn't exist!");
                               Application.Exit();
                           }
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
