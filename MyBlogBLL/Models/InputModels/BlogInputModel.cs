using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogBLL.Models.InputModels
{
    public class BlogInputModel
    {
        [Required]
        [MaxLength(80, ErrorMessage = "Name of the blog can be up to 80 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Description of the blog can be up to 150 characters")]
        public string Description { get; set; }
    }
}
