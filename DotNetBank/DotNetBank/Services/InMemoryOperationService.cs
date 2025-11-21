using System.Collections.Generic;
using System.Linq;
using DotNetBank.Data;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    /// <summary>
    /// Petar Ivanov, F116389 - In-memory услуга за регистриране и извличане на операции.
    /// </summary>
    public class InMemoryOperationService : IOperationService
    {
        /// <summary>
        /// Petar Ivanov, F116389 - Добавя нов запис за операция с IBAN, тип и сума.
        /// </summary>
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

        /// <summary>
        /// Petar Ivanov, F116389 - Връща всички операции за конкретна сметка.
        /// </summary>
        public IEnumerable<OperationRecord> GetForAccount(string iban) =>
            InMemoryStore.Operations.Where(o => o.Iban == iban);

        /// <summary>
        /// Petar Ivanov, F116389 - Извежда всички операции от хранилището.
        /// </summary>
        public IEnumerable<OperationRecord> GetAll() => InMemoryStore.Operations;
    }
}