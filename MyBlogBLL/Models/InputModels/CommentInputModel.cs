﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogBLL.Models.InputModels
{
    public class CommentInputModel
    {
        public string Content { get; set; }
        public int ArticleId { get; set; }
    }
}