using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogDAL.Entities;
using MyBlogDAL.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL
{
    public sealed class MyBlogDBContext : IdentityDbContext<User>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public MyBlogDBContext(DbContextOptions<MyBlogDBContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
