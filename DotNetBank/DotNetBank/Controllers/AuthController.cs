using DotNetBank.Models;
using DotNetBank.Services;

namespace DotNetBank.Controllers
{
    /// <summary>
    /// Отговаря за login/register логиката.
    /// </summary>
    public class AuthController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public UserProfile Login(string username, string password)
        {
            var user = _userService.Login(username, password);
            if (user != null)
            {
                SessionContext.SignIn(user);
            }
            return user;
        }

        public UserProfile Register(string username, string password, UserRole role = UserRole.Standard)
        {
            var user = _userService.Register(username, password, role);
            // Можеш да добавиш изпращане на welcome e-mail тук при реална интеграция.
            return user;
        }
    }
}