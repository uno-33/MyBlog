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
            return _dbSet.AsQueryable().Include(x => x.Creator);
        }

        public async Task<IQueryable<Article>> GetArticlesByBlogId(int id)
        {
            var entity = await GetByIdWithDetailsAsync(id);

            if (entity == null)
                return null;

            await _dBContext.Entry(entity).Collection(x => x.Articles).LoadAsync();

            return entity.Articles.AsQueryable();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            _dBContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<Blog> GetByIdWithDetailsAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            await _dBContext.Entry(entity).Navigation(nameof(entity.Creator)).LoadAsync();

            return entity;
        }

        public void Update(Blog entity)
        {

            _dbSet.Attach(entity);
            _dBContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
