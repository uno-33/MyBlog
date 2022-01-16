using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }

        public bool IsValid()
        {
            if (Name.Length == 0 || CreatorId.Length == 0 || Description.Length == 0)
                return false;

            return true;
        }
    }
}
