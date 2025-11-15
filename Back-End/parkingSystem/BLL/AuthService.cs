using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterAsync(User user)
        {
            if (await _userRepository.EmailExistsAsync(user.Email))
                throw new Exception("Email already exists");

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
        }
    }
}
