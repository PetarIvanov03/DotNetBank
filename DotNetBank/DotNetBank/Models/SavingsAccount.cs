using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    public sealed class SavingsAccount : BankAccount
    {
        public decimal MonthlyInterestPercent { get; set; } = 0.8m;

        public SavingsAccount(string code, string owner, string currency)
            : base(code, owner, currency) { }

        /// <summary>Начисляване на месечна лихва (прост пример).</summary>
        public void ApplyMonthlyInterest()
        {
            if (Balance <= 0) return;
            var interest = Balance * (MonthlyInterestPercent / 100m);
            Deposit(interest);
        }

        public override void Withdraw(decimal amount)
        {
            // По-консервативно теглене (без доп. такси тук).
            base.Withdraw(amount);
        }
        public override string ToString()
        {
            return base.ToString() + $", Type: {this.GetType()}";
        }
    }
}
