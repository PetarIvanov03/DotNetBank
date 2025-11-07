using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Helpers
{
    public sealed class BalanceChangedEventArgs : EventArgs
    {
        public string Code { get; }
        public decimal OldBalance { get; }
        public decimal NewBalance { get; }
        public DateTime At { get; }

        public BalanceChangedEventArgs(string code, decimal oldBalance, decimal newBalance, DateTime at)
        {
            Code = code;
            OldBalance = oldBalance;
            NewBalance = newBalance;
            At = at;
        }
    }
}
