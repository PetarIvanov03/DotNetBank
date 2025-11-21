using System.Collections.Generic;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    /// <summary>
    /// Petar Ivanov, F116389 - Контракт за услуги, управляващи банкови сметки.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Petar Ivanov, F116389 - Създава нова сметка по зададена заявка.
        /// </summary>
        BankAccount Create(AccountCreationRequest request);

        /// <summary>
        /// Petar Ivanov, F116389 - Връща сметки за конкретен собственик.
        /// </summary>
        IEnumerable<BankAccount> GetByOwner(string ownerName);

        /// <summary>
        /// Petar Ivanov, F116389 - Доставя всички налични сметки.
        /// </summary>
        IEnumerable<BankAccount> GetAll();

        /// <summary>
        /// Petar Ivanov, F116389 - Намира сметка по IBAN.
        /// </summary>
        BankAccount Find(string iban);

        /// <summary>
        /// Petar Ivanov, F116389 - Внася средства по сметка с описание.
        /// </summary>
        void Deposit(string iban, decimal amount, string description = null);

        /// <summary>
        /// Petar Ivanov, F116389 - Тегли средства от сметка с описание.
        /// </summary>
        void Withdraw(string iban, decimal amount, string description = null);
    }
}