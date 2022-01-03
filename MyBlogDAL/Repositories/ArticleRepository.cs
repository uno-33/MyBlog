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

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            return true;
        }

        public IQueryable<Article> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IQueryable<Comment>> GetCommentsByArticleId(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            return entity.Comments.AsQueryable();
        }

        public async Task<IQueryable<Tag>> GetTagsByArticleId(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            return entity.Tags.AsQueryable();
        }

        public void Update(Article entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
