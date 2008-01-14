using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TheEarthQuake.Logic;
using TheEarthQuake.Engine;

namespace TheEarthQuake.GUI
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

            WelcomeForm form = new WelcomeForm();
            Application.Run(form);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Wyst¹pi³ b³¹d");
        }
    }
}
