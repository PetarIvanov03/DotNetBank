using System.Collections.Generic;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    /// <summary>
    /// Petar Ivanov, F116389 - Контракт за услуги за регистриране и извличане на операции.
    /// </summary>
    public interface IOperationService
    {
        /// <summary>
        /// Petar Ivanov, F116389 - Добавя нов запис за операция върху сметка.
        /// </summary>
        OperationRecord Log(string iban, OperationType type, decimal amount, string description = null);

        /// <summary>
        /// Petar Ivanov, F116389 - Връща операции за конкретен IBAN.
        /// </summary>
        IEnumerable<OperationRecord> GetForAccount(string iban);

        /// <summary>
        /// Petar Ivanov, F116389 - Извежда всички записани операции.
        /// </summary>
        IEnumerable<OperationRecord> GetAll();
    }
}