using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<bool> EmailExistsAsync(string email);
    }
}
