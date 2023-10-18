using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Addit.AK.WBD.AK_Suche.AuthService;

namespace Addit.AK.WBD.AK_Suche
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {              
            AKK_Helper.authService = new AuthServiceClient(); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_AK_Suche(args));
        }
    }
}
