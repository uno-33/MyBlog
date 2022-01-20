using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class AuthModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string DateOfCreation { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string Token { get; set; }
        public int TokenExpiresIn { get; set; }
    }
}
