namespace DotNetBank
{
    partial class MainPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.TabPage tabOperations;
        private System.Windows.Forms.DataGridView gridAccounts;
        private System.Windows.Forms.DataGridView gridOperations;
        private System.Windows.Forms.TextBox txtIban;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.NumericUpDown nudInitialBalance;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblIban;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblInitial;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtFilterOwner;
        private System.Windows.Forms.Button btnFilterOwner;
        private System.Windows.Forms.TextBox txtOperationIban;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Label lblOperationIban;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnRefreshOperations;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnFilterOwner = new System.Windows.Forms.Button();
            this.txtFilterOwner = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblInitial = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblIban = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.nudInitialBalance = new System.Windows.Forms.NumericUpDown();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.txtIban = new System.Windows.Forms.TextBox();
            this.gridAccounts = new System.Windows.Forms.DataGridView();
            this.tabOperations = new System.Windows.Forms.TabPage();
            this.btnRefreshOperations = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblOperationIban = new System.Windows.Forms.Label();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.txtOperationIban = new System.Windows.Forms.TextBox();
            this.gridOperations = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInitialBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).BeginInit();
            this.tabOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOperations)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAccounts);
            this.tabControl1.Controls.Add(this.tabOperations);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.lblStatus);
            this.tabAccounts.Controls.Add(this.btnFilterOwner);
            this.tabAccounts.Controls.Add(this.txtFilterOwner);
            this.tabAccounts.Controls.Add(this.lblType);
            this.tabAccounts.Controls.Add(this.lblInitial);
            this.tabAccounts.Controls.Add(this.lblCurrency);
            this.tabAccounts.Controls.Add(this.lblOwner);
            this.tabAccounts.Controls.Add(this.lblIban);
            this.tabAccounts.Controls.Add(this.cmbType);
            this.tabAccounts.Controls.Add(this.btnCreate);
            this.tabAccounts.Controls.Add(this.nudInitialBalance);
            this.tabAccounts.Controls.Add(this.txtCurrency);
            this.tabAccounts.Controls.Add(this.txtOwner);
            this.tabAccounts.Controls.Add(this.txtIban);
            this.tabAccounts.Controls.Add(this.gridAccounts);
            this.tabAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccounts.Size = new System.Drawing.Size(792, 424);
            this.tabAccounts.TabIndex = 0;
            this.tabAccounts.Text = "Сметки";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 194);
            this.lblStatus.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 14;
            // 
            // btnFilterOwner
            // 
            this.btnFilterOwner.Location = new System.Drawing.Point(640, 16);
            this.btnFilterOwner.Name = "btnFilterOwner";
            this.btnFilterOwner.Size = new System.Drawing.Size(130, 23);
            this.btnFilterOwner.TabIndex = 13;
            this.btnFilterOwner.Text = "Филтрирай по клиент";
            this.btnFilterOwner.UseVisualStyleBackColor = true;
            this.btnFilterOwner.Click += new System.EventHandler(this.btnFilterOwner_Click);
            // 
            // txtFilterOwner
            // 
            this.txtFilterOwner.Location = new System.Drawing.Point(470, 18);
            this.txtFilterOwner.Name = "txtFilterOwner";
            this.txtFilterOwner.Size = new System.Drawing.Size(164, 20);
            this.txtFilterOwner.TabIndex = 12;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(15, 156);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 13);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Тип:";
            // 
            // lblInitial
            // 
            this.lblInitial.AutoSize = true;
            this.lblInitial.Location = new System.Drawing.Point(15, 125);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(95, 13);
            this.lblInitial.TabIndex = 10;
            this.lblInitial.Text = "Начален баланс:";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(15, 96);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(46, 13);
            this.lblCurrency.TabIndex = 9;
            this.lblCurrency.Text = "Валута:";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(15, 66);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(59, 13);
            this.lblOwner.TabIndex = 8;
            this.lblOwner.Text = "Собственик";
            // 
            // lblIban
            // 
            this.lblIban.AutoSize = true;
            this.lblIban.Location = new System.Drawing.Point(15, 35);
            this.lblIban.Name = "lblIban";
            this.lblIban.Size = new System.Drawing.Size(35, 13);
            this.lblIban.TabIndex = 7;
            this.lblIban.Text = "IBAN";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            DotNetBank.Models.AccountKind.Checking,
            DotNetBank.Models.AccountKind.Savings,
            DotNetBank.Models.AccountKind.Student});
            this.cmbType.Location = new System.Drawing.Point(116, 153);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(188, 21);
            this.cmbType.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(18, 223);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(286, 32);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Създай сметка";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // nudInitialBalance
            // 
            this.nudInitialBalance.DecimalPlaces = 2;
            this.nudInitialBalance.Location = new System.Drawing.Point(116, 123);
            this.nudInitialBalance.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudInitialBalance.Name = "nudInitialBalance";
            this.nudInitialBalance.Size = new System.Drawing.Size(188, 20);
            this.nudInitialBalance.TabIndex = 4;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(116, 93);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(188, 20);
            this.txtCurrency.TabIndex = 3;
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(116, 63);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(188, 20);
            this.txtOwner.TabIndex = 2;
            // 
            // txtIban
            // 
            this.txtIban.Location = new System.Drawing.Point(116, 32);
            this.txtIban.Name = "txtIban";
            this.txtIban.Size = new System.Drawing.Size(188, 20);
            this.txtIban.TabIndex = 1;
            // 
            // gridAccounts
            // 
            this.gridAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccounts.Location = new System.Drawing.Point(370, 50);
            this.gridAccounts.Name = "gridAccounts";
            this.gridAccounts.Size = new System.Drawing.Size(400, 350);
            this.gridAccounts.TabIndex = 0;
            // 
            // tabOperations
            // 
            this.tabOperations.Controls.Add(this.btnRefreshOperations);
            this.tabOperations.Controls.Add(this.lblDescription);
            this.tabOperations.Controls.Add(this.txtDescription);
            this.tabOperations.Controls.Add(this.lblAmount);
            this.tabOperations.Controls.Add(this.lblOperationIban);
            this.tabOperations.Controls.Add(this.btnWithdraw);
            this.tabOperations.Controls.Add(this.btnDeposit);
            this.tabOperations.Controls.Add(this.nudAmount);
            this.tabOperations.Controls.Add(this.txtOperationIban);
            this.tabOperations.Controls.Add(this.gridOperations);
            this.tabOperations.Location = new System.Drawing.Point(4, 22);
            this.tabOperations.Name = "tabOperations";
            this.tabOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperations.Size = new System.Drawing.Size(792, 424);
            this.tabOperations.TabIndex = 1;
            this.tabOperations.Text = "Операции";
            this.tabOperations.UseVisualStyleBackColor = true;
            // 
            // btnRefreshOperations
            // 
            this.btnRefreshOperations.Location = new System.Drawing.Point(18, 223);
            this.btnRefreshOperations.Name = "btnRefreshOperations";
            this.btnRefreshOperations.Size = new System.Drawing.Size(286, 30);
            this.btnRefreshOperations.TabIndex = 9;
            this.btnRefreshOperations.Text = "Обнови списъка";
            this.btnRefreshOperations.UseVisualStyleBackColor = true;
            this.btnRefreshOperations.Click += new System.EventHandler(this.btnRefreshOperations_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 139);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 13);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Описание/Бел.";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(18, 155);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(286, 57);
            this.txtDescription.TabIndex = 7;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(15, 88);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Сума:";
            // 
            // lblOperationIban
            // 
            this.lblOperationIban.AutoSize = true;
            this.lblOperationIban.Location = new System.Drawing.Point(15, 26);
            this.lblOperationIban.Name = "lblOperationIban";
            this.lblOperationIban.Size = new System.Drawing.Size(35, 13);
            this.lblOperationIban.TabIndex = 5;
            this.lblOperationIban.Text = "IBAN";
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(152, 114);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(152, 23);
            this.btnWithdraw.TabIndex = 4;
            this.btnWithdraw.Text = "Теглене";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(18, 114);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(128, 23);
            this.btnDeposit.TabIndex = 3;
            this.btnDeposit.Text = "Внасяне";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(74, 86);
            this.nudAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(230, 20);
            this.nudAmount.TabIndex = 2;
            // 
            // txtOperationIban
            // 
            this.txtOperationIban.Location = new System.Drawing.Point(74, 23);
            this.txtOperationIban.Name = "txtOperationIban";
            this.txtOperationIban.Size = new System.Drawing.Size(230, 20);
            this.txtOperationIban.TabIndex = 1;
            // 
            // gridOperations
            // 
            this.gridOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOperations.Location = new System.Drawing.Point(370, 23);
            this.gridOperations.Name = "gridOperations";
            this.gridOperations.Size = new System.Drawing.Size(400, 377);
            this.gridOperations.TabIndex = 0;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            this.Controls.Add(this.tabControl1);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DotNetBank";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAccounts.ResumeLayout(false);
            this.tabAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInitialBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).EndInit();
            this.tabOperations.ResumeLayout(false);
            this.tabOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOperations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}