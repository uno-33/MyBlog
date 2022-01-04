using MyBlogBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public interface ITagService
    {
        Task AddAsync(TagModel model);
        void Delete(TagModel model);
        Task<bool> DeleteByIdAsync(int id);
        IEnumerable<TagModel> GetAll();
        Task<TagModel> GetByIdAsync(int id);
        Task<TagModel> GetByNameAsync(string name);
        void Update(TagModel model);
    }
}