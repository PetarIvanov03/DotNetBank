using System.Collections.Generic;
using System.Linq;
using DotNetBank.Data;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    public class InMemoryOperationService : IOperationService
    {
        public OperationRecord Log(string iban, OperationType type, decimal amount, string description = null)
        {
            var record = new OperationRecord
            {
                Iban = iban,
                Type = type,
                Amount = amount,
                Description = description
            };

            InMemoryStore.Operations.Add(record);
            return record;
        }

        public IEnumerable<OperationRecord> GetForAccount(string iban) =>
            InMemoryStore.Operations.Where(o => o.Iban == iban);

        public IEnumerable<OperationRecord> GetAll() => InMemoryStore.Operations;
    }
}