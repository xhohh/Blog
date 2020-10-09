using AutoMapper;
using FatTiger.Blog.Application.Contracts.Blog;
using FatTiger.Blog.Application.Contracts.Blog.Params;
using FatTiger.Blog.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application
{
    public class FatTigerBlogAutoMapperProfile : Profile
    {
        public FatTigerBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<FriendLink, FriendLinkDto>();

            CreateMap<EditPostInput, Post>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Post, PostForAdminDto>().ForMember(x => x.Tags, opt => opt.Ignore());
        }
    }
}
