﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogBLL.Models.InputModels
{
    public class ArticleInputModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}