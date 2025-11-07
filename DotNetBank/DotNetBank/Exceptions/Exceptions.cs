using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Exceptions
{
    public sealed class InvalidAmountException : Exception
    {
        public InvalidAmountException(string msg) : base(msg) { }
    }

    public sealed class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string msg) : base(msg) { }
    }

    public sealed class DuplicateAccountCodeException : Exception
    {
        public string Code { get; }
        public DuplicateAccountCodeException(string code) : base($"Duplicate account code: {code}") => Code = code;
    }
}
