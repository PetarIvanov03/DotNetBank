using System.Collections.Generic;
using DotNetBank.Models;

namespace DotNetBank.Services
{
    public interface IUserService
    {
        UserProfile Register(string username, string password, UserRole role = UserRole.Standard);
        UserProfile Login(string username, string password);
        IEnumerable<UserProfile> GetAll();
    }
}
