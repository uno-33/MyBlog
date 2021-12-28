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
        IUserRepository _userRepository;
        IBlogRepository _blogRepository;
        IArticleRepository _articleRepository;
        ICommentRepository _commentRepository;
        ITagRepository _tagRepository;

        public UnitOfWork(MyBlogDBContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
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
    }
}
