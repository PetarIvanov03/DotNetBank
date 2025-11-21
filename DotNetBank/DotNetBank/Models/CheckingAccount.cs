using DotNetBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    /// <summary>
    /// Petar Ivanov, F116389 - Чекова сметка с такса за теглене и минимален баланс.
    /// </summary>
    public sealed class CheckingAccount : BankAccount
    {
        public decimal WithdrawFee { get; set; } = 0.30m; // плоска такса на теглене
        public decimal MinBalance { get; set; } = 0m;     // напр. може да изискаш >= 0

        /// <summary>
        /// Petar Ivanov, F116389 - Създава нова чекова сметка с начални стойности.
        /// </summary>
        /// <param name="code">IBAN код.</param>
        /// <param name="owner">Име на собственика.</param>
        /// <param name="currency">Валутен код.</param>
        /// <param name="initial">Начално салдо.</param>
        public CheckingAccount(string code, string owner, string currency, decimal initial)
            : base(code, owner, currency)
        {

        }

        /// <summary>
        /// Petar Ivanov, F116389 - Тегли сума като включва такса и валидира минималния баланс.
        /// </summary>
        /// <param name="amount">Сумата за теглене.</param>
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new InvalidAmountException("Amount must be > 0.");

            // общото „дебитиране“ включва сумата + таксата
            decimal totalDebit = amount + WithdrawFee;

            // гарантираме, че няма да паднем под минимално допустим баланс
            if (Balance - totalDebit < MinBalance)
                throw new InsufficientFundsException("Insufficient funds for amount + fee or min balance would be violated.");

            var old = Balance;
            Balance -= totalDebit;

            // (по желание) можеш да логнеш fee като отделна Operation с тип Fee в сервиза

        }
    }
}
