using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogBLL.Models
{
    public class JwtModel
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
