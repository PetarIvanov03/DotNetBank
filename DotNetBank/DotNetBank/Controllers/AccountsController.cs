using System;
using System.Collections.Generic;
using DotNetBank.Models;
using DotNetBank.Services;

namespace DotNetBank.Controllers
{
    /// <summary>
    /// Petar Ivanov, F116389 - Слоят между формите и услугите за банкови сметки, който управлява операциите за текущия потребител.
    /// </summary>
    public class AccountsController
    {
        private readonly IAccountService _accountService;
        private readonly IOperationService _operationService;

        /// <summary>
        /// Petar Ivanov, F116389 - Създава нов контролер за банкови сметки с необходимите услуги.
        /// </summary>
        /// <param name="accountService">Услуга за управление на сметки.</param>
        /// <param name="operationService">Услуга за регистриране на операции.</param>
        public AccountsController(IAccountService accountService, IOperationService operationService)
        {
            _accountService = accountService;
            _operationService = operationService;
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Създава нова банкова сметка според предоставената заявка.
        /// </summary>
        /// <param name="request">DTO с данните за сметката.</param>
        /// <returns>Създаденият обект <see cref="BankAccount"/>.</returns>
        public BankAccount Create(AccountCreationRequest request)
        {
            return _accountService.Create(request);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Връща списък с банкови сметки за текущо логнатия потребител.
        /// </summary>
        /// <returns>Колекция от сметки или празен списък, ако няма активен потребител.</returns>
        public IEnumerable<BankAccount> ListAccounts()
        {
            var currentUser = SessionContext.CurrentUser;
            if (currentUser == null) return Array.Empty<BankAccount>();

            return _accountService.GetByOwner(currentUser.Username);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Извежда всички операции или тези за конкретна сметка по IBAN.
        /// </summary>
        /// <param name="iban">IBAN на сметката (по избор).</param>
        /// <returns>Списък с операции.</returns>
        public IEnumerable<OperationRecord> ListOperations(string iban = null)
        {
            return string.IsNullOrWhiteSpace(iban) ? _operationService.GetAll() : _operationService.GetForAccount(iban);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Заделя депозит по даден IBAN.
        /// </summary>
        /// <param name="iban">Сметката, в която се внасят средства.</param>
        /// <param name="amount">Сумата за депозит.</param>
        /// <param name="description">Описание на операцията.</param>
        public void Deposit(string iban, decimal amount, string description)
        {
            _accountService.Deposit(iban, amount, description);
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Извършва теглене от посочен IBAN.
        /// </summary>
        /// <param name="iban">Сметката, от която се тегли.</param>
        /// <param name="amount">Сумата за теглене.</param>
        /// <param name="description">Описание на операцията.</param>
        public void Withdraw(string iban, decimal amount, string description)
        {
            _accountService.Withdraw(iban, amount, description);
        }
    }
}