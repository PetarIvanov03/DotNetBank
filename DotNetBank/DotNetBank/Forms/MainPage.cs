using DotNetBank.Controllers;
using DotNetBank.Models;
using System;
using System.Linq;
using System.Windows.Forms;

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
            MakeGridNonClickable(gridAccounts);
            MakeGridNonClickable(gridOperations);

            txtOwner.Text = SessionContext.CurrentUser?.Username;
            txtOwner.ReadOnly = true;
            if (cmbType.Items.Count > 0)
            {
                cmbType.SelectedIndex = 0;
            }
            RefreshAccounts();
            RefreshOperations();
        }

        private void RefreshAccounts()
        {
            gridAccounts.DataSource = _accountsController.ListAccounts().ToList();
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
                if (string.IsNullOrWhiteSpace(txtOperationIban.Text))
                {
                    MessageBox.Show("Моля, въведете IBAN преди внасяне.", "Липсващ IBAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _accountsController.Deposit(txtOperationIban.Text, nudAmount.Value, txtDescription.Text);
                RefreshAccounts();
                RefreshOperations();
                lblStatus.Text = "Успешно внесохте средства.";
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
                if (string.IsNullOrWhiteSpace(txtOperationIban.Text))
                {
                    MessageBox.Show("Моля, въведете IBAN преди теглене.", "Липсващ IBAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _accountsController.Withdraw(txtOperationIban.Text, nudAmount.Value, txtDescription.Text);
                RefreshAccounts();
                RefreshOperations();
                lblStatus.Text = "Успешно изтеглихте средства.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefreshOperations_Click(object sender, EventArgs e)
        {
            RefreshOperations();
        }
    }
}