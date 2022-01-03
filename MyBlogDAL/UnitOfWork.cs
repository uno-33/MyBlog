using Microsoft.AspNetCore.Identity;
using MyBlogDAL.Entities;
using MyBlogDAL.Interfaces;
using MyBlogDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBlogDBContext _context;
        private IBlogRepository _blogRepository;
        private IArticleRepository _articleRepository;
        private ICommentRepository _commentRepository;
        private ITagRepository _tagRepository;

        public UnitOfWork(MyBlogDBContext context)
        {
            _context = context;
        }

        public IBlogRepository BlogRepository
        {
            get
            {
                if (_blogRepository == null)
                {
                    _blogRepository = new BlogRepository(_context);
                }
                return _blogRepository;
            }
        }

        public IArticleRepository ArticleRepository 
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(_context);
                }
                return _articleRepository;
            }
        }

        public ICommentRepository CommentRepository 
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_context);
                }
                return _commentRepository;
            }
        }

        public ITagRepository TagRepository 
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(_context);
                }
                return _tagRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region Dispose
        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    #endregion
}
