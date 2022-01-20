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
            //CreateMap<User, UserModel>();

            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<Comment, CommentModel>().ReverseMap();
            CreateMap<Comment, CommentModel>()
                .ForMember(cm => cm.AuthorName, i => i.MapFrom(c => c.Author.UserName))
                .ForMember(cm => cm.DateOfCreation, i => i.MapFrom(c => c.DateOfCreation.ToString("MMMM dd, yyyy - H:mm")));

            CreateMap<Article, ArticleModel>().ReverseMap();
            CreateMap<Article, ArticleModel>()
                .ForMember(cm => cm.CreatorName, i => i.MapFrom(c => c.Creator.UserName))
                .ForMember(cm => cm.DateOfCreation, i => i.MapFrom(c => c.DateOfCreation.ToString("MMMM dd, yyyy - H:mm")));

            CreateMap<Blog, BlogModel>().ReverseMap();
            CreateMap<Blog, BlogModel>()
                .ForMember(bm => bm.CreatorName, i => i.MapFrom(b => b.Creator.UserName));

            CreateMap<Tag, TagModel>().ReverseMap();
            CreateMap<Tag, TagModel>();
        }
    }
}
