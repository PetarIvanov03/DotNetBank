using System;
using System.Collections.Generic;
using System.Linq;
using DotNetBank.Data;
using DotNetBank.Exceptions;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    /// <summary>
    /// Petar Ivanov, F116389 - In-memory имплементация на услуги за банкови сметки.
    /// </summary>
    public class InMemoryAccountService : IAccountService
    {
        private readonly IOperationService _operationService;

        /// <summary>
        /// Petar Ivanov, F116389 - Инжектира услуга за операции за автоматично логване.
        /// </summary>
        public InMemoryAccountService(IOperationService operationService)
        {
            _operationService = operationService;
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Създава банкова сметка според заявката и логва началното салдо.
        /// </summary>
        public BankAccount Create(AccountCreationRequest request)
        {
            if (InMemoryStore.Accounts.Any(a => a.IBAN == request.Iban))
            {
                throw new DuplicateAccountCodeException(request.Iban);
            }

            BankAccount account;
            switch (request.Kind)
            {
                case AccountKind.Savings:
                    account = new SavingsAccount(request.Iban, request.OwnerName, request.Currency);
                    break;

                case AccountKind.Student:
                    account = new StudentAccount(request.Iban, request.OwnerName, request.Currency);
                    break;

                default:
                    account = new CheckingAccount(request.Iban, request.OwnerName, request.Currency, request.InitialBalance);
                    break;
            }


            if (request.InitialBalance > 0)
            {
                account.Deposit(request.InitialBalance);
                _operationService.Log(account.IBAN, OperationType.Deposit, request.InitialBalance, "Начално салдо");
            }

            InMemoryStore.Accounts.Add(account);
            return account;
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Връща всички сметки за даден собственик.
        /// </summary>
        public IEnumerable<BankAccount> GetByOwner(string ownerName) =>
            InMemoryStore.Accounts.Where(a => string.Equals(a.OwnerName, ownerName, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Petar Ivanov, F116389 - Връща всички съхранени сметки.
        /// </summary>
        public IEnumerable<BankAccount> GetAll() => InMemoryStore.Accounts;

        /// <summary>
        /// Petar Ivanov, F116389 - Намира конкретна сметка по IBAN.
        /// </summary>
        public BankAccount Find(string iban) =>
            InMemoryStore.Accounts.FirstOrDefault(a => a.IBAN == iban);

        /// <summary>
        /// Petar Ivanov, F116389 - Внася средства в посочен IBAN и създава запис за операцията.
        /// </summary>
        public void Deposit(string iban, decimal amount, string description = null)
        {
            var account = RequireAccount(iban);
            account.Deposit(amount);
            _operationService.Log(account.IBAN, OperationType.Deposit, amount, description);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Тегли средства от IBAN и логва операцията.
        /// </summary>
        public void Withdraw(string iban, decimal amount, string description = null)
        {
            var account = RequireAccount(iban);
            account.Withdraw(amount);
            _operationService.Log(account.IBAN, OperationType.Withdraw, amount, description);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Валидира, че сметката съществува и я връща.
        /// </summary>
        private static BankAccount RequireAccount(string iban)
        {
            var account = InMemoryStore.Accounts.FirstOrDefault(a => a.IBAN == iban);
            if (account == null) throw new ArgumentException($"Не е намерена сметка с IBAN {iban}", nameof(iban));
            return account;
        }
    }
}