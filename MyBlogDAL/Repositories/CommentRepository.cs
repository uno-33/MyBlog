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

        public IQueryable<Comment> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(Comment entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
