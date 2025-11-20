using System.Collections.Generic;
using DotNetBank.Models;
using DotNetBank.Services;

namespace DotNetBank.Controllers
{
    /// <summary>
    /// Слоят между формите и услугите за банкови сметки.
    /// </summary>
    public class AccountsController
    {
        private readonly IAccountService _accountService;
        private readonly IOperationService _operationService;

        public AccountsController(IAccountService accountService, IOperationService operationService)
        {
            _accountService = accountService;
            _operationService = operationService;
        }

        public BankAccount Create(AccountCreationRequest request)
        {
            return _accountService.Create(request);
        }

        public IEnumerable<BankAccount> ListAccounts(string owner = null)
        {
            if (string.IsNullOrWhiteSpace(owner)) return _accountService.GetAll();
            return _accountService.GetByOwner(owner);
        }

        public IEnumerable<OperationRecord> ListOperations(string iban = null)
        {
            return string.IsNullOrWhiteSpace(iban) ? _operationService.GetAll() : _operationService.GetForAccount(iban);
        }

        public void Deposit(string iban, decimal amount, string description)
        {
            _accountService.Deposit(iban, amount, description);
        }

        public void Withdraw(string iban, decimal amount, string description)
        {
            _accountService.Withdraw(iban, amount, description);
        }
    }
}