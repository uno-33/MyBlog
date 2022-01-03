using MyBlogBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public interface IBlogService
    {
        Task AddAsync(BlogModel model);
        void Delete(BlogModel model);
        Task<bool> DeleteByIdAsync(int id);
        IEnumerable<BlogModel> GetAll();
        Task<IEnumerable<ArticleModel>> GetArticlesByBlogId(int id);
        Task<BlogModel> GetByIdAsync(int id);
        void Update(BlogModel model);
    }
}