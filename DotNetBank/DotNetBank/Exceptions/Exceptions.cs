using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Exceptions
{
    /// <summary>
    /// Petar Ivanov, F116389 - Изключение за невалидна сума.
    /// </summary>
    public sealed class InvalidAmountException : Exception
    {
        /// <summary>
        /// Petar Ivanov, F116389 - Създава ново изключение за невалидна сума.
        /// </summary>
        public InvalidAmountException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Petar Ivanov, F116389 - Изключение при липса на средства.
    /// </summary>
    public sealed class InsufficientFundsException : Exception
    {
        /// <summary>
        /// Petar Ivanov, F116389 - Създава изключение при опит за теглене над наличното.
        /// </summary>
        public InsufficientFundsException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Petar Ivanov, F116389 - Изключение при дублиран IBAN код.
    /// </summary>
    public sealed class DuplicateAccountCodeException : Exception
    {
        public string Code { get; }

        /// <summary>
        /// Petar Ivanov, F116389 - Създава изключение с информация за дублирания код.
        /// </summary>
        public DuplicateAccountCodeException(string code) : base($"Duplicate account code: {code}") => Code = code;
    }
}
