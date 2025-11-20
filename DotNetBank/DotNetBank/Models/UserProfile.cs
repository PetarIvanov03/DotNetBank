using System;

namespace DotNetBank.Models
{
    /// <summary>
    /// Представлява потребителски профил за вход в системата.
    /// </summary>
    public class UserProfile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Standard;
    }

    public enum UserRole
    {
        Standard,
        Administrator
    }
}
