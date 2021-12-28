using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag GetByName(string name);
    }
}
