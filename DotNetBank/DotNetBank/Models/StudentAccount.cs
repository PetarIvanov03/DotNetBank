using DotNetBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    /// <summary>
    /// Petar Ivanov, F116389 - Студентска сметка с ограничен брой безплатни тегления и минимална такса.
    /// </summary>
    public sealed class StudentAccount : BankAccount
    {
        public int FreeWithdrawalsLeft { get; set; } = 10;
        public decimal WithdrawFee { get; set; } = 0.10m;

        /// <summary>
        /// Petar Ivanov, F116389 - Конструира студентска сметка със собственик и валута.
        /// </summary>
        /// <param name="code">IBAN код.</param>
        /// <param name="owner">Име на собственика.</param>
        /// <param name="currency">Валутен код.</param>
        public StudentAccount(string code, string owner, string currency)
            : base(code, owner, currency) { }

        /// <summary>
        /// Petar Ivanov, F116389 - Тегли сума, като прилага такса след изчерпване на безплатните тегления.
        /// </summary>
        /// <param name="amount">Сумата за теглене.</param>
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new InvalidAmountException("Amount must be > 0.");
            var fee = (FreeWithdrawalsLeft > 0) ? 0m : WithdrawFee;
            var total = amount + fee;
            if (Balance < total) throw new InsufficientFundsException("Not enough funds for amount + fee.");

            var old = Balance;
            Balance -= total;
            if (FreeWithdrawalsLeft > 0) FreeWithdrawalsLeft--;

        }
    }
}
