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
    public class BlogRepository : IBlogRepository
    {
        private readonly MyBlogDBContext _context;
        private readonly DbSet<Blog> _blogs;

        public BlogRepository(MyBlogDBContext context)
        {
            _context = context;
            _blogs = context.Blogs;
        }
        public Task AddAsync(Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Blog> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetArticlesByBlogId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
