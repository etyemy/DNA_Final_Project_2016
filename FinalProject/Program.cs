using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Xml;
using System.Text;
using FinalProject.UI;

namespace FinalProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoAnalyzeSplashScreenForm splashScreen = new AutoAnalyzeSplashScreenForm();

            splashScreen.Shown += new EventHandler((o, e) =>
            {
                System.Threading.Thread t = new System.Threading.Thread(() =>
                {
                    System.Threading.Thread.Sleep(5000);
                    splashScreen.Invoke(new Action(() => { splashScreen.Close(); }));

                });
                t.IsBackground = true;
                t.Start();
            });

            Application.Run(splashScreen);
            Application.Run(new MainForm());
        }

    }
}
