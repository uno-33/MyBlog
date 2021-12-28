using Microsoft.EntityFrameworkCore;
using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL
{
    public class MyBlogDBContext : DbContext
    {
        public MyBlogDBContext(DbContextOptions<MyBlogDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
