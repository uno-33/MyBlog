using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBlogRepository BlogRepository { get; }
        IArticleRepository ArticleRepository { get; }
        ICommentRepository CommentRepository { get; }
        ITagRepository TagRepository { get; }
        Task<int> SaveAsync();
    }
}
