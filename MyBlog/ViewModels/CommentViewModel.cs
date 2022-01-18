using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public int ArticleId { get; set; }
    }
}
