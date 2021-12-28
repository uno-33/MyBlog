using Microsoft.EntityFrameworkCore;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly MyBlogDBContext _context;
        private readonly DbSet<Tag> _tags;

        public TagRepository(MyBlogDBContext context)
        {
            _context = context;
            _tags = context.Tags;
        }
        public Task AddAsync(Tag entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tag entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tag> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Tag GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
