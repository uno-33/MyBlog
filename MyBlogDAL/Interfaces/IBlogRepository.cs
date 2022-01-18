using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<IQueryable<Article>> GetArticlesByBlogId(int id);
        Task<Blog> GetByIdWithDetailsAsync(int id);
    }
}
