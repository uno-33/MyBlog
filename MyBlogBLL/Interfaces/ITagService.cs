using MyBlogBLL.Models;
using MyBlogDAL.Entities;
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
        Task<Tag> GetByNameAsync(string name);
        void Update(TagModel model);
    }
}