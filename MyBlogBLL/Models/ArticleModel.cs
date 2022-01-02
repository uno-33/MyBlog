using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int BlogId { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public ICollection<int> CommentsIds { get; set; }
        public ICollection<int> TagsIds { get; set; }

    }
}
