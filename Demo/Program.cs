﻿using OpenNextOneDrive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoenZomers.OneDrive.AuthenticatorApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("config.json"))
            {
                Application.Run(new MainForm());
            }
            if (!File.Exists("config.json"))
            {
                Application.Run(new FrmConfgiuracao());
            }
           
        }
    }
}
