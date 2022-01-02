using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL.Entities
{
    public class Tag : BaseEntity
    {
        public string Text { get; set; }

        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
