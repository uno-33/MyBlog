using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyBlogDBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly DbSet<User> _users;

        public UserRepository(MyBlogDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _users = context.Users;
        }

        public async Task<bool> AddUserToRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, role);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<bool> DeleteById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }

        public IQueryable<Article> GetArticlesByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Blog> GetBlogsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetCommentsByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
