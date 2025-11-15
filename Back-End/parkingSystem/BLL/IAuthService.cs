using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(User user);
        Task<User?> LoginAsync(string email, string password);
    }
}
