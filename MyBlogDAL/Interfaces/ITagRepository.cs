using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag> GetByNameAsync(string name);
    }
}
