using System;

namespace DotNetBank.Models
{
    /// <summary>
    /// Просто хранилище за текущия потребител по време на изпълнение.
    /// </summary>
    public static class SessionContext
    {
        public static UserProfile CurrentUser { get; private set; }

        public static void SignIn(UserProfile user)
        {
            CurrentUser = user;
        }

        public static void SignOut()
        {
            CurrentUser = null;
        }
    }
}
