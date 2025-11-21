using DotNetBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Models
{
    /// <summary>
    /// Petar Ivanov, F116389 - Абстрактна база за всички банкови сметки, съдържаща общите свойства и операции.
    /// </summary>
    public abstract class BankAccount
    {
        public string IBAN { get; }
        public string OwnerName { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Petar Ivanov, F116389 - Конструктор за инициализиране на IBAN, собственик и валута.
        /// </summary>
        /// <param name="IBAN">Уникален IBAN на сметката.</param>
        /// <param name="OwnerName">Име на собственика.</param>
        /// <param name="Currency">Валутен код.</param>
        protected BankAccount(string IBAN, string OwnerName, string Currency)
        {
            this.IBAN = IBAN;
            this.OwnerName = OwnerName;
            this.Currency = Currency;
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Депозира посочената сума след валидиране на стойността.
        /// </summary>
        /// <param name="amount">Сумата за депозит.</param>
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new InvalidAmountException("Amount must be > 0.");
            var old = Balance;
            Balance += amount;

        }

        /// <summary>
        /// Petar Ivanov, F116389 - Тегли средства от сметката, ако има наличност и сумата е валидна.
        /// </summary>
        /// <param name="amount">Сумата за теглене.</param>
        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new InvalidAmountException("Amount must be > 0.");
            if (Balance < amount) throw new InsufficientFundsException("Not enough funds.");
            var old = Balance;
            Balance -= amount;

        }

        /// <summary>
        /// Petar Ivanov, F116389 - Връща четливо описание на сметката за целите на дебъг и UI.
        /// </summary>
        /// <returns>Текстово описание с IBAN и собственик.</returns>
        public override string ToString()
        {
            return $"This bank account (IBAN:{IBAN}) is owned by {this.OwnerName}";
        }

    }
}
