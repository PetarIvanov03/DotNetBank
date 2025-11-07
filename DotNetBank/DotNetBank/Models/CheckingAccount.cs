using DotNetBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    public sealed class CheckingAccount : BankAccount
    {
        public decimal WithdrawFee { get; set; } = 0.30m; // плоска такса на теглене
        public decimal MinBalance { get; set; } = 0m;     // напр. може да изискаш >= 0

        public CheckingAccount(string code, string owner, string currency, decimal initial)
            : base(code, owner, currency)
        {

        }

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

            BalanceChanged?.Invoke(this, new BalanceChangedEventArgs(Code, old, Balance, DateTime.Now));
        }
    }
}
