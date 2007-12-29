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

            Controller gameController = new Controller();
            WelcomeFormControllerWrapper welcomeFormControllerWrapper =
                new WelcomeFormControllerWrapper(gameController);

            WelcomeForm form = new WelcomeForm(welcomeFormControllerWrapper);
            Application.Run(form);
        }
    }
}
