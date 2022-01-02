using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUserToRoleAsync(string id, string role);
        IQueryable<Article> GetArticlesByUserId(string id);
        IQueryable<Blog> GetBlogsByUserId(int id);
        IQueryable<Comment> GetCommentsByUserId(int id);
    }
}
