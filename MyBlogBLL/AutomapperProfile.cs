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
            CreateMap<User, UserModel>()
                .ForMember(um => um.ArticlesIds, i => i.MapFrom(u => u.Articles.Select(x => x.Id)))
                .ForMember(um => um.BlogsIds, i => i.MapFrom(u => u.Blogs.Select(x => x.Id)))
                .ForMember(um => um.CommentsIds, i => i.MapFrom(u => u.Comments.Select(x => x.Id)));

            CreateMap<User, UserModel>()
                .ForMember(um => um.ArticlesIds, i => i.MapFrom(u => u.Articles.Select(x => x.Id)))
                .ForMember(um => um.BlogsIds, i => i.MapFrom(u => u.Blogs.Select(x => x.Id)))
                .ForMember(um => um.CommentsIds, i => i.MapFrom(u => u.Comments.Select(x => x.Id)))
                .ReverseMap();
        }
    }
}
