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
        Task<IEnumerable<CommentModel>> GetCommentsByArticleId(int id);
        Task<IEnumerable<TagModel>> GetTagsByArticleId(int id);
        void Update(ArticleModel model);
        IEnumerable<ArticleModel> GetByFilter(ArticleFilterModel filter);
    }
}