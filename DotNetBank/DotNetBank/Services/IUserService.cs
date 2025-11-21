using System.Collections.Generic;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    /// <summary>
    /// Petar Ivanov, F116389 - Контракт за услуги, управляващи потребители и автентикация.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Petar Ivanov, F116389 - Регистрира нов потребител с роля.
        /// </summary>
        UserProfile Register(string username, string password, UserRole role = UserRole.Standard);

        /// <summary>
        /// Petar Ivanov, F116389 - Извършва вход по потребителско име и парола.
        /// </summary>
        UserProfile Login(string username, string password);

        /// <summary>
        /// Petar Ivanov, F116389 - Извлича всички регистрирани потребители.
        /// </summary>
        IEnumerable<UserProfile> GetAll();
    }
}