using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    /// <summary>
    /// Petar Ivanov, F116389 - Спестовна сметка с основна лихва и стандартно теглене.
    /// </summary>
    public sealed class SavingsAccount : BankAccount
    {
        public decimal MonthlyInterestPercent { get; set; } = 0.8m;

        /// <summary>
        /// Petar Ivanov, F116389 - Инициализира спестовна сметка с IBAN, собственик и валута.
        /// </summary>
        /// <param name="code">IBAN код.</param>
        /// <param name="owner">Име на собственика.</param>
        /// <param name="currency">Валутен код.</param>
        public SavingsAccount(string code, string owner, string currency)
            : base(code, owner, currency) { }

        /// <summary>
        /// Petar Ivanov, F116389 - Начислява проста месечна лихва при налично положително салдо.
        /// </summary>
        public void ApplyMonthlyInterest()
        {
            if (Balance <= 0) return;
            var interest = Balance * (MonthlyInterestPercent / 100m);
            Deposit(interest);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Позволява теглене без допълнителни такси чрез базовата логика.
        /// </summary>
        /// <param name="amount">Сумата за теглене.</param>
        public override void Withdraw(decimal amount)
        {
            // По-консервативно теглене (без доп. такси тук).
            base.Withdraw(amount);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Допълва описанието на сметката с типа на класа.
        /// </summary>
        /// <returns>Текстово описание на сметката и типа.</returns>
        public override string ToString()
        {
            return base.ToString() + $", Type: {this.GetType()}";
        }
    }
}
