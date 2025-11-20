using System.Collections.Generic;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    public interface IOperationService
    {
        OperationRecord Log(string iban, OperationType type, decimal amount, string description = null);
        IEnumerable<OperationRecord> GetForAccount(string iban);
        IEnumerable<OperationRecord> GetAll();
    }
}