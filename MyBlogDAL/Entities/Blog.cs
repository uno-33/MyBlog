using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL.Entities
{
    public class Blog : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
