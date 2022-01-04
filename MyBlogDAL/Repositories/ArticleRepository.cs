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
            return _dbSet.AsQueryable()
                .Include(x => x.Blog)
                .Include(x => x.Creator);
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            await _dbContext.Entry(entity).Navigation(nameof(entity.Creator)).LoadAsync();

            return entity;
        }

        public async Task<IQueryable<Comment>> GetCommentsByArticleId(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            await _dbContext.Entry(entity).Collection(x => x.Comments).LoadAsync();

            return entity.Comments.AsQueryable();
        }

        public async Task<IQueryable<Tag>> GetTagsByArticleId(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            await _dbContext.Entry(entity).Collection(x => x.Tags).LoadAsync();

            return entity.Tags.AsQueryable();
        }

        public void Update(Article entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
