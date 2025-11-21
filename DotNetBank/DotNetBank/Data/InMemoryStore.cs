using System.Collections.Generic;
using DotNetBank.Models;

namespace DotNetBank.Data
{
    /// <summary>
    /// Petar Ivanov, F116389 - Статичен "in-memory" склад за данни за целите на демонстрацията.
    /// </summary>
    public static class InMemoryStore
    {
        public static List<UserProfile> Users { get; } = new List<UserProfile>();
        public static List<BankAccount> Accounts { get; } = new List<BankAccount>();
        public static List<OperationRecord> Operations { get; } = new List<OperationRecord>();
    }
}