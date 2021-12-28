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
        private readonly MyBlogDBContext _context;
        private readonly DbSet<Article> _articles;

        public ArticleRepository(MyBlogDBContext context)
        {
            _context = context;
            _articles = context.Articles;
        }
        public Task AddAsync(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetCommentsByArticleId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tag> GetTagsByArticleId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}
