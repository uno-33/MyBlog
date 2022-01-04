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
        private readonly MyBlogDBContext _dbContext;
        private readonly DbSet<Tag> _dbSet;

        public TagRepository(MyBlogDBContext context)
        {
            _dbContext = context;
            _dbSet = context.Tags;
        }

        public async Task AddAsync(Tag entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(Tag entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<Tag> FindAll()
        {
            return _dbSet.AsQueryable()
                .Include(x => x.Creator);
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            await _dbContext.Entry(entity).Navigation(nameof(entity.Creator)).LoadAsync();

            return entity;
        }

        public async Task<Tag> GetByNameAsync(string name)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Text == name);
            if (entity == null)
                return null;

            await _dbContext.Entry(entity).Navigation(nameof(entity.Creator)).LoadAsync();

            return entity;
        }

        public void Update(Tag entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
