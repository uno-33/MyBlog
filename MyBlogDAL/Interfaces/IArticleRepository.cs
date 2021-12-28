using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogDAL.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        IQueryable<Comment> GetCommentsByArticleId(int id);
        IQueryable<Tag> GetTagsByArticleId(int id);
    }
}
