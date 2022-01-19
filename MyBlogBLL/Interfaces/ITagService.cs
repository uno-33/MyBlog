using MyBlogBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public interface ITagService
    {
        Task AddToArticleAsync(int articleId, string tagName);
        Task<bool> DeleteByIdAsync(int id);
        Task<IEnumerable<TagModel>> GetAllByArticleIdAsync(int id);
        Task<TagModel> GetByNameAsync(string name);
        Task RemoveFromArticleAsync(int articleId, string tagName);
    }
}