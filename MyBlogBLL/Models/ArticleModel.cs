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
        public string DateOfCreation { get; set; }
        public int BlogId { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }

        public bool IsValid()
        {
            if (Title.Length == 0 || 
                Content.Length == 0 || 
                DateOfCreation.Length == 0 || 
                CreatorId.Length == 0)
                return false;

            return true;
        }

    }
}
