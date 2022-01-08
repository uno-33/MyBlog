using MyBlogBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public interface IArticleService
    {
        Task AddAsync(ArticleModel model);
        void Delete(ArticleModel model);
        Task<bool> DeleteByIdAsync(int id);
        IEnumerable<ArticleModel> GetAll();
        Task<ArticleModel> GetByIdAsync(int id);
        IEnumerable<ArticleModel> GetByMatchingText(string text);
        Task<IEnumerable<ArticleModel>> GetByTag(string tagName);
        Task<IEnumerable<CommentModel>> GetCommentsByArticleId(int id);
        IEnumerable<ArticleModel> GetLatest(int count = 5);
        Task<IEnumerable<TagModel>> GetTagsByArticleId(int id);
        void Update(ArticleModel model);
    }
}