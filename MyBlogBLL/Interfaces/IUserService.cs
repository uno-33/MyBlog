using System.Threading.Tasks;

namespace MyBlogBLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUserToRoleAsync(string id, string role);
    }
}