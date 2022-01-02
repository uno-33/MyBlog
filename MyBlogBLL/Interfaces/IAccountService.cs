using MyBlogBLL.Models;
using System.Threading.Tasks;

namespace MyBlogBLL.Interfaces
{
    public interface IAccountService
    {
        Task<UserModel> LoginAsync(LoginModel model);
        Task<bool> RegisterAsync(RegisterModel model);
    }
}