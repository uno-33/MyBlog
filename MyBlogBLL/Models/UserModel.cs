using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Token { get; set; }
    }
}
