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
        private readonly DbSet<User> _users;

        public UserRepository(MyBlogDBContext context)
        {
            _context = context;
            _users = context.Users;
        }
        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetArticlesByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Blog> GetBlogsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetCommentsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
