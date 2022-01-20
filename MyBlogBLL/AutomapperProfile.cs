using AutoMapper;
using MyBlogBLL.Models;
using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogBLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserModel>();
            //    .ForMember(um => um.ArticlesIds, i => i.MapFrom(u => u.Articles.Select(x => x.Id)))
            //    .ForMember(um => um.BlogsIds, i => i.MapFrom(u => u.Blogs.Select(x => x.Id)))
            //    .ForMember(um => um.CommentsIds, i => i.MapFrom(u => u.Comments.Select(x => x.Id)));

            CreateMap<User, UserModel>()
            //    .ForMember(um => um.ArticlesIds, i => i.MapFrom(u => u.Articles.Select(x => x.Id)))
            //    .ForMember(um => um.BlogsIds, i => i.MapFrom(u => u.Blogs.Select(x => x.Id)))
            //    .ForMember(um => um.CommentsIds, i => i.MapFrom(u => u.Comments.Select(x => x.Id)))
                .ReverseMap();

            CreateMap<Comment, CommentModel>()
                //.ForMember(cm => cm.AuthorName, i => i.MapFrom(c => c.Author.UserName))
                .ReverseMap();
            CreateMap<Comment, CommentModel>()
                .ForMember(cm => cm.AuthorName, i => i.MapFrom(c => c.Author.UserName));

            CreateMap<Article, ArticleModel>()
            //    //.ForMember(cm => cm.CreatorName, i => i.MapFrom(c => c.Creator.UserName))
            //    .ForMember(cm => cm.CommentsIds, i => i.MapFrom(a => a.Comments.Select(x => x.Id)))
            //    .ForMember(cm => cm.TagsIds, i => i.MapFrom(a => a.Tags.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<Article, ArticleModel>()
                .ForMember(cm => cm.CreatorName, i => i.MapFrom(c => c.Creator.UserName))
                .ForMember(cm => cm.DateOfCreation, i => i.MapFrom(c => c.DateOfCreation.ToString("MMMM dd, yyyy - H:mm")));
            //.ForMember(cm => cm.CommentsIds, i => i.MapFrom(a => a.Comments.Select(x => x.Id)))
            //.ForMember(cm => cm.TagsIds, i => i.MapFrom(a => a.Tags.Select(x => x.Id)));

            CreateMap<Blog, BlogModel>()
            //    //.ForMember(bm => bm.CreatorName, i => i.MapFrom(b => b.Creator.UserName))
            //    .ForMember(bm => bm.ArticlesIds, i => i.MapFrom(b => b.Articles.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<Blog, BlogModel>()
                .ForMember(bm => bm.CreatorName, i => i.MapFrom(b => b.Creator.UserName));
            //.ForMember(bm => bm.ArticlesIds, i => i.MapFrom(b => b.Articles.Select(x => x.Id)));

            CreateMap<Tag, TagModel>()
            //    //.ForMember(tm => tm.CreatorName, i => i.MapFrom(t => t.Creator.UserName))
            //    .ForMember(tm => tm.ArticlesIds, i => i.MapFrom(t => t.Articles.Select(x => x.Id)))
                .ReverseMap();
            CreateMap<Tag, TagModel>();
                //.ForMember(tm => tm.CreatorName, i => i.MapFrom(t => t.Creator.UserName));
                //.ForMember(tm => tm.ArticlesIds, i => i.MapFrom(t => t.Articles.Select(x => x.Id)));
        }
    }
}
