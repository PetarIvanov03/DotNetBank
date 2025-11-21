using DotNetBank.Models;
using DotNetBank.Services;

namespace DotNetBank.Controllers
{
    /// <summary>
    /// Petar Ivanov, F116389 - Отговаря за логиката по вход и регистрация на потребители.
    /// </summary>
    public class AuthController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Petar Ivanov, F116389 - Инжектира услуга за потребители за нуждите на автентикацията.
        /// </summary>
        /// <param name="userService">Услуга за управление на потребители.</param>
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Опит за вход с потребителско име и парола, като запазва сесията при успех.
        /// </summary>
        /// <param name="username">Потребителско име.</param>
        /// <param name="password">Парола.</param>
        /// <returns>Профилът на потребителя или null при неуспех.</returns>
        public UserProfile Login(string username, string password)
        {
            var user = _userService.Login(username, password);
            if (user != null)
            {
                SessionContext.SignIn(user);
            }
            return user;
        }

        /// <summary>
        /// Petar Ivanov, F116389 - Регистрира нов потребител и връща създадения профил.
        /// </summary>
        /// <param name="username">Потребителско име.</param>
        /// <param name="password">Парола.</param>
        /// <param name="role">Роля на потребителя.</param>
        /// <returns>Новият потребителски профил.</returns>
        public UserProfile Register(string username, string password, UserRole role = UserRole.Standard)
        {
            var user = _userService.Register(username, password, role);
            // Можеш да добавиш изпращане на welcome e-mail тук при реална интеграция.
            return user;
        }
    }
}