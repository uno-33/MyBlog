using MyBlogBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public interface IArticleService
    {
        Task AddAsync(ArticleModel model);
        Task<bool> DeleteByIdAsync(int id);
        IEnumerable<ArticleModel> GetAll();
        Task<ArticleModel> GetByIdAsync(int id);
        Task<ArticleModel> GetByIdWithDetailsAsync(int id);
        IEnumerable<ArticleModel> GetByMatchingText(string text);
        Task<IEnumerable<ArticleModel>> GetByTagAsync(string tagName);
        IEnumerable<ArticleModel> GetLatest(int count = 5);
        void Update(ArticleModel model);
    }
}