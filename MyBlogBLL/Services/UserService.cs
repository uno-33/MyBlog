using MyBlogBLL.Interfaces;
using MyBlogDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUserToRoleAsync(string id, string role)
        {
            return await _userRepository.AddUserToRoleAsync(id, role); ;
        }
    }
}
