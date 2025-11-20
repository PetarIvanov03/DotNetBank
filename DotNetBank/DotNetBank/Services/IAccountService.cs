using System.Collections.Generic;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    public interface IAccountService
    {
        BankAccount Create(AccountCreationRequest request);
        IEnumerable<BankAccount> GetByOwner(string ownerName);
        IEnumerable<BankAccount> GetAll();
        BankAccount Find(string iban);
        void Deposit(string iban, decimal amount, string description = null);
        void Withdraw(string iban, decimal amount, string description = null);
    }
}
