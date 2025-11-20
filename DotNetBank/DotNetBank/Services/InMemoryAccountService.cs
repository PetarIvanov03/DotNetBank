using System;
using System.Collections.Generic;
using System.Linq;
using DotNetBank.Data;
using DotNetBank.Exceptions;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    public class InMemoryAccountService : IAccountService
    {
        private readonly IOperationService _operationService;

        public InMemoryAccountService(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public BankAccount Create(AccountCreationRequest request)
        {
            if (InMemoryStore.Accounts.Any(a => a.IBAN == request.Iban))
            {
                throw new DuplicateAccountCodeException(request.Iban);
            }

            BankAccount account = request.Kind switch
            {
                AccountKind.Savings => new SavingsAccount(request.Iban, request.OwnerName, request.Currency),
                AccountKind.Student => new StudentAccount(request.Iban, request.OwnerName, request.Currency),
                _ => new CheckingAccount(request.Iban, request.OwnerName, request.Currency, request.InitialBalance)
            };

            if (request.InitialBalance > 0)
            {
                account.Deposit(request.InitialBalance);
                _operationService.Log(account.IBAN, OperationType.Deposit, request.InitialBalance, "Начално салдо");
            }

            InMemoryStore.Accounts.Add(account);
            return account;
        }

        public IEnumerable<BankAccount> GetByOwner(string ownerName) =>
            InMemoryStore.Accounts.Where(a => string.Equals(a.OwnerName, ownerName, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<BankAccount> GetAll() => InMemoryStore.Accounts;

        public BankAccount Find(string iban) =>
            InMemoryStore.Accounts.FirstOrDefault(a => a.IBAN == iban);

        public void Deposit(string iban, decimal amount, string description = null)
        {
            var account = RequireAccount(iban);
            account.Deposit(amount);
            _operationService.Log(account.IBAN, OperationType.Deposit, amount, description);
        }

        public void Withdraw(string iban, decimal amount, string description = null)
        {
            var account = RequireAccount(iban);
            account.Withdraw(amount);
            _operationService.Log(account.IBAN, OperationType.Withdraw, amount, description);
        }

        private static BankAccount RequireAccount(string iban)
        {
            var account = InMemoryStore.Accounts.FirstOrDefault(a => a.IBAN == iban);
            if (account == null) throw new ArgumentException($"Не е намерена сметка с IBAN {iban}", nameof(iban));
            return account;
        }
    }
}
