using DotNetBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    public abstract class BankAccount
    {
        public string IBAN { get; }
        public string OwnerName { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; protected set; }

        protected BankAccount(string IBAN, string OwnerName, string Currency)
        {
            this.IBAN = IBAN;
            this.OwnerName = OwnerName;
            this.Currency = Currency;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new InvalidAmountException("Amount must be > 0.");
            var old = Balance;
            Balance += amount;

        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new InvalidAmountException("Amount must be > 0.");
            if (Balance < amount) throw new InsufficientFundsException("Not enough funds.");
            var old = Balance;
            Balance -= amount;

        }
        public override string ToString()
        {
            return $"This bank account (IBAN:{IBAN}) is owned by {this.OwnerName}";
        }

    }
}
