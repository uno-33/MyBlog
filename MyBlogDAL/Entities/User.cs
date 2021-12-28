using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
