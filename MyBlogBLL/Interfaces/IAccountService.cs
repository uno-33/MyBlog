using MyBlogBLL.Models;
using MyBlogBLL.Models.InputModels;
using System.Threading.Tasks;

namespace MyBlogBLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> LoginAsync(AuthInputModel model);
        Task<bool> RegisterAsync(AuthInputModel model);
    }
}