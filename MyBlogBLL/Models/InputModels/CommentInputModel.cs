using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogBLL.Models.InputModels
{
    public class CommentInputModel
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Comment can be up to 200 characters")]
        public string Content { get; set; }
        [Required]
        public int ArticleId { get; set; }
    }
}
