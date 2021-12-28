using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogDAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Authenticate(string username, string password);
        IQueryable<Comment> GetCommentsByUserId(int id);
        IQueryable<Article> GetArticlesByUserId(int id);
        IQueryable<Blog> GetBlogsByUserId(int id);
    }
}
