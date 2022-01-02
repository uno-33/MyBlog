using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogDAL.EntityConfigurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.Content)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
