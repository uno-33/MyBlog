using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int ArticleId { get; set; }
    }
}
