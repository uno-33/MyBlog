using MyBlogBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public interface ICommentService
    {
        Task AddAsync(CommentModel model);
        Task<bool> DeleteByIdAsync(int id);
        IEnumerable<CommentModel> GetAll();
        Task<IEnumerable<CommentModel>> GetAllByArticleIdAsync(int id);
        Task<CommentModel> GetByIdAsync(int id);
        void Update(CommentModel model);
    }
}