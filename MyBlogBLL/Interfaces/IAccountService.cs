using MyBlogBLL.Models;
using System.Threading.Tasks;

namespace MyBlogBLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<bool> RegisterAsync(RegisterModel model);
    }
}