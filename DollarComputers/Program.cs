// ______________________________________________________________________________________________
// App name:           Dollar Computers
// Author's name:      Harshit Sharma
// Student Number#:    200333254
// App Creation Date:  March 12, 2017
// Last Modified Date: April 02, 2017
// Professor:          Tom Tsiliopoulos
// Rapid Application Development - Assignment 4
// App description:    This application allows the user to buy a hardware product from the provided
//                     data and save that to a config file. Also, user can load file in the form.
// ________________________________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DollarComputers
{
    static class Program
    {
        // declared public static form - Application GLOBAL
        public static SplashScreen MySplashScreen;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize SplashForm and CalculatorForm
            Program.MySplashScreen = new SplashScreen();

            Application.Run(Program.MySplashScreen);
        }
    }
}
