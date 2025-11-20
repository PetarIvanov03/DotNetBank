// Petar Ivanov, F116389 - Entry point for the DotNetBank WinForms application.
using System;
using System.Windows.Forms;
using DotNetBank.Controllers;
using DotNetBank.Services;

namespace DotNetBank
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Инициализиране на in-memory услугите и контролерите.
            var operationService = new InMemoryOperationService();
            var accountService = new InMemoryAccountService(operationService);
            var userService = new InMemoryUserService();
            var authController = new AuthController(userService);
            var accountsController = new AccountsController(accountService, operationService);

            Application.Run(new LoginForm(authController, accountsController));
        }
    }
}
