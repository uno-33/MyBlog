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
        private readonly MyBlogDBContext _dBContext;
        private readonly DbSet<Blog> _dbSet;

        public BlogRepository(MyBlogDBContext context)
        {
            _dBContext = context;
            _dbSet = context.Blogs;
        }

        public async Task AddAsync(Blog entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(Blog entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Blog> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IQueryable<Article>> GetArticlesByBlogId(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return null;

            return entity.Articles.AsQueryable();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(Blog entity)
        {
            _dbSet.Attach(entity);
            _dBContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
