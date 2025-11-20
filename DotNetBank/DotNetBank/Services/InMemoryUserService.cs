using System;
using System.Collections.Generic;
using System.Linq;
using DotNetBank.Data;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    /// <summary>
    /// Прост in-memory UserService. Паролите са в чист текст за целите на упражнението.
    /// </summary>
    public class InMemoryUserService : IUserService
    {
        public UserProfile Register(string username, string password, UserRole role = UserRole.Standard)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username required", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password required", nameof(password));

            if (InMemoryStore.Users.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Потребителското име вече е заето.");
            }

            var user = new UserProfile
            {
                Username = username.Trim(),
                Password = password,
                Role = role
            };

            InMemoryStore.Users.Add(user);
            return user;
        }

        public UserProfile Login(string username, string password)
        {
            var user = InMemoryStore.Users.FirstOrDefault(u =>
                string.Equals(u.Username, username?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            return user;
        }

        public IEnumerable<UserProfile> GetAll() => InMemoryStore.Users;
    }
}