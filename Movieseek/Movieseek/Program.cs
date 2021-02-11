using Movieseek.Pages.Auth;
using Movieseek.Services;
using System;
using System.Windows.Forms;

namespace Movieseek
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

            // api service
            var APIService = new APIService();
            APIService.InitializeAPIService();

            // show the login page
            Application.Run(new Login());
        }
    }
}
