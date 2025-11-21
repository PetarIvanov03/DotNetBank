using System;

namespace DotNetBank.Models
{
    /// <summary>
    /// Petar Ivanov, F116389 - Представлява потребителски профил за вход в системата.
    /// </summary>
    public class UserProfile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Standard;
    }

    /// <summary>
    /// Petar Ivanov, F116389 - Налични роли за достъп в приложението.
    /// </summary>
    public enum UserRole
    {
        Standard,
        Administrator
    }
}