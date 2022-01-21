using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogBLL.Models.InputModels
{
    public class ArticleInputModel
    {
        [Required]
        [MaxLength(80,ErrorMessage = "Title can be up to 80 characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Content can be up to 1000 characters")]
        public string Content { get; set; }
        [Required]
        public int BlogId { get; set; }
    }
}
