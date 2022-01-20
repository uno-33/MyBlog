using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public bool IsValid()
        {
            if (Text.Length == 0)
                return false;

            return true;
        }
    }
}
