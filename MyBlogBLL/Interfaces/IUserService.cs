using MyBlogBLL.Models;
using MyBlogBLL.Models.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogBLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUserToRoleAsync(string id, string role);
        Task<bool> RemoveUserFromRoleAsync(string id, string role);
        Task<bool> DeleteByIdAsync(string id);
        IEnumerable<UserModel> GetAll();
        Task<IEnumerable<ArticleModel>> GetArticlesByUserIdAsync(string id);
        Task<IEnumerable<BlogModel>> GetBlogsByUserIdAsync(string id);
        Task<UserModel> GetByIdAsync(string id);
        Task<IEnumerable<CommentModel>> GetCommentsByUserIdAsync(string id);
        Task<string> UpdateByIdAsync(string id, UserInputModel model);
        Task<IEnumerable<string>> GetRolesByUserIdAsync(string id);
    }
}