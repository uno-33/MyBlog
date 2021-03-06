using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogBLL.Models.InputModels
{
    public class TagInputModel
    {
        [Required]
        [MaxLength(16, ErrorMessage = "Tag can be up to 16 characters")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Name { get; set; }
    }
}
