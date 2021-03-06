using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> GetByIdWithDetailsAsync(int id);
    }
}
