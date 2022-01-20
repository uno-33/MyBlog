using MyBlogBLL.Models;
using MyBlogBLL.Models.InputModels;
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
        IEnumerable<BlogModel> GetLatest(int count = 5);
        Task<int> Update(int id, BlogInputModel model);
        Task<BlogModel> GetByIdWithDetailsAsync(int id);
    }
}