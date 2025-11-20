// Petar Ivanov, F116389 - Main form definition for the DotNetBank application.
using System;
using System.Linq;
using System.Windows.Forms;
using DotNetBank.Controllers;
using DotNetBank.Models;

namespace DotNetBank
{
    /// <summary>
    /// Представя основния изглед на приложението.
    /// </summary>
    public partial class MainPage : Form
    {
        private readonly AccountsController _accountsController;

        public MainPage(AccountsController accountsController)
        {
            _accountsController = accountsController;
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            txtOwner.Text = SessionContext.CurrentUser?.Username;
            if (cmbType.Items.Count > 0)
            {
                cmbType.SelectedIndex = 0;
            }
            RefreshAccounts();
            RefreshOperations();
        }

        private void RefreshAccounts()
        {
            gridAccounts.DataSource = _accountsController.ListAccounts(txtFilterOwner.Text).ToList();
        }

        private void RefreshOperations()
        {
            gridOperations.DataSource = _accountsController.ListOperations(txtOperationIban.Text).ToList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new AccountCreationRequest
                {
                    Iban = txtIban.Text,
                    OwnerName = txtOwner.Text,
                    Currency = txtCurrency.Text,
                    InitialBalance = nudInitialBalance.Value,
                    Kind = (AccountKind)cmbType.SelectedItem
                };

                _accountsController.Create(request);
                RefreshAccounts();
                RefreshOperations();
                lblStatus.Text = "Сметката е създадена.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                _accountsController.Deposit(txtOperationIban.Text, nudAmount.Value, txtDescription.Text);
                RefreshAccounts();
                RefreshOperations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                _accountsController.Withdraw(txtOperationIban.Text, nudAmount.Value, txtDescription.Text);
                RefreshAccounts();
                RefreshOperations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFilterOwner_Click(object sender, EventArgs e)
        {
            RefreshAccounts();
        }

        private void btnRefreshOperations_Click(object sender, EventArgs e)
        {
            RefreshOperations();
        }
    }
}
