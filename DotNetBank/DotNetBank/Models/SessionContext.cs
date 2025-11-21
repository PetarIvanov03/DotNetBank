using System;

namespace DotNetBank.Models
{
    /// <summary>
    /// Petar Ivanov, F116389 - Просто хранилище за текущия потребител по време на изпълнение.
    /// </summary>
    public static class SessionContext
    {
        public static UserProfile CurrentUser { get; private set; }

        /// <summary>
        /// Petar Ivanov, F116389 - Задава активния потребител след успешен вход.
        /// </summary>
        /// <param name="user">Профилът за вписване.</param>
        public static void SignIn(UserProfile user)
        {
            CurrentUser = user;
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Премахва информацията за текущия потребител при изход.
        /// </summary>
        public static void SignOut()
        {
            CurrentUser = null;
        }
    }
}