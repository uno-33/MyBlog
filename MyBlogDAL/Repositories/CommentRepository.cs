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
    public class CommentRepository : ICommentRepository
    {
        private readonly MyBlogDBContext _dbContext;
        private readonly DbSet<Comment> _dbSet;

        public CommentRepository(MyBlogDBContext context)
        {
            _dbContext = context;
            _dbSet = context.Comments;
        }

        public async Task AddAsync(Comment entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(Comment entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Comment> FindAll()
        {
            return _dbSet.AsQueryable()
                //.Include(x => x.Article)
                .Include(x => x.Author);
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<Comment> GetByIdWithDetailsAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            await _dbContext.Entry(entity).Navigation(nameof(entity.Author)).LoadAsync();

            return entity;
        }

        public void Update(Comment entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
