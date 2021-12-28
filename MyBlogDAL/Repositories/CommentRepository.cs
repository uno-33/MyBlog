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
        private readonly MyBlogDBContext _context;
        private readonly DbSet<Comment> _comments;

        public CommentRepository(MyBlogDBContext context)
        {
            _context = context;
            _comments = context.Comments;
        }
        public Task AddAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
