using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public ICollection<int> ArticlesIds { get; set; }
    }
}
