using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public ICollection<int> ArticlesIds { get; set; }
    }
}
