using Microsoft.AspNetCore.Identity;
using MyBlogBLL.Interfaces;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUserToRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.Succeeded;
        }
    }
}
