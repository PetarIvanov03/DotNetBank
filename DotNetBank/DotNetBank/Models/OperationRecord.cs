using System;

namespace DotNetBank.Models
{
    /// <summary>
    /// Проста операция над банкова сметка за целите на демонстрацията.
    /// </summary>
    public class OperationRecord
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Iban { get; set; }
        public OperationType Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public enum OperationType
    {
        Deposit,
        Withdraw,
        Transfer,
        Fee
    }
}
