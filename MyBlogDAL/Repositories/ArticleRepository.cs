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
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyBlogDBContext _dbContext;
        private readonly DbSet<Article> _dbSet;

        public ArticleRepository(MyBlogDBContext context)
        {
            _dbContext = context;
            _dbSet = context.Articles;
        }
        public async Task AddAsync(Article entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(Article entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Article> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Article> GetByIdWithDetailsAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            await _dbContext.Entry(entity).Navigation(nameof(entity.Creator)).LoadAsync();

            return entity;
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }


        public void Update(Article entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
