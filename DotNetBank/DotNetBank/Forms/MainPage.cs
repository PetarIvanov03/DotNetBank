using DotNetBank.Controllers;
using DotNetBank.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DotNetBank
{
    /// <summary>
    /// Petar Ivanov, F116389 - Представя основния изглед на приложението.
    /// </summary>
    public partial class MainPage : Form
    {

        private readonly AccountsController _accountsController;

        /// <summary>
        /// Petar Ivanov, F116389 - Инжектира контролера за сметки и инициализира формата.
        /// </summary>
        public MainPage(AccountsController accountsController)
        {
            _accountsController = accountsController;
            InitializeComponent();
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Зарежда началните данни за сметки и операции.
        /// </summary>
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

        /// <summary>
        /// Petar Ivanov, F116389 - Обновява таблицата със сметки.
        /// </summary>
        private void RefreshAccounts()
        {
            gridAccounts.DataSource = _accountsController.ListAccounts().ToList();
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Обновява таблицата с операции по зададен IBAN филтър.
        /// </summary>
        private void RefreshOperations()
        {
            gridOperations.DataSource = _accountsController.ListOperations(txtOperationIban.Text).ToList();
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Създава нова сметка от въведените данни.
        /// </summary>
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

        /// <summary>
        /// Petar Ivanov, F116389 - Извършва депозит към избран IBAN и обновява изгледите.
        /// </summary>
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

        /// <summary>
        /// Petar Ivanov, F116389 - Извършва теглене от IBAN и обновява изгледите.
        /// </summary>
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

        /// <summary>
        /// Petar Ivanov, F116389 - Презарежда списъка с операции според текущия IBAN филтър.
        /// </summary>
        private void btnRefreshOperations_Click(object sender, EventArgs e)
        {
            RefreshOperations();
        }
    }
}