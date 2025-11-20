using DotNetBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    public sealed class StudentAccount : BankAccount
    {
        public int FreeWithdrawalsLeft { get; set; } = 10;
        public decimal WithdrawFee { get; set; } = 0.10m;

        public StudentAccount(string code, string owner, string currency)
            : base(code, owner, currency) { }

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
