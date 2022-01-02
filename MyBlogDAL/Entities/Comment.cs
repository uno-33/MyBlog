using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }

        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
