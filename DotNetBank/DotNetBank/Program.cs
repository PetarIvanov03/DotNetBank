// Petar Ivanov, F116389 - Entry point for the DotNetBank WinForms application.

using System;
using System.Windows.Forms;
using DotNetBank.Controllers;
using DotNetBank.Services;

namespace DotNetBank
{
    /// <summary>
    /// Petar Ivanov, F116389 - Основният клас, който стартира WinForms приложението и инициализира зависимостите.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Petar Ivanov, F116389 - Основна входна точка, която конфигурира визуалните стилове и стартира формата за вход.
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
