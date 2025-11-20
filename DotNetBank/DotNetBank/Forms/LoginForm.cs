using System;
using System.Windows.Forms;
using DotNetBank.Controllers;
using DotNetBank.Models;

namespace DotNetBank
{
    public partial class LoginForm : Form
    {
        private readonly AuthController _authController;
        private readonly AccountsController _accountsController;

        public LoginForm(AuthController authController, AccountsController accountsController)
        {
            _authController = authController;
            _accountsController = accountsController;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _authController.Login(txtUsername.Text, txtPassword.Text);
            if (user == null)
            {
                lblFeedback.Text = "Невалидно потребителско име или парола.";
                return;
            }

            // След успешно влизане отваряме главната страница с вече създадените контролери.
            Hide();
            var main = new MainPage(_accountsController)
            {
                Text = $"DotNetBank - {user.Username}"
            };
            main.FormClosed += (s, args) => Close();
            main.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                _authController.Register(txtUsername.Text, txtPassword.Text, chkAdmin.Checked ? UserRole.Administrator : UserRole.Standard);
                lblFeedback.Text = "Успешно създадохте профил. Опитайте да влезете.";
            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.Message;
            }
        }
    }
}
