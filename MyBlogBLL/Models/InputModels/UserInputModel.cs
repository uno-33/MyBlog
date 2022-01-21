using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBlogBLL.Models.InputModels
{
    public class UserInputModel
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Username can be up to 200 characters")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string UserName { get; set; }
    }
}
