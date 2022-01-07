using MyBlogBLL.Models;
using System.Threading.Tasks;

namespace MyBlogBLL.Interfaces
{
    public interface IAccountService
    {
        Task<JwtModel> LoginAsync(LoginModel model);
        Task<bool> RegisterAsync(RegisterModel model);
    }
}