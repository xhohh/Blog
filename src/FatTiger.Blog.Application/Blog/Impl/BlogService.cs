using FatTiger.Blog.Application.Caching.Blog;
using FatTiger.Blog.Application.Contracts;
using FatTiger.Blog.Application.Contracts.Blog;
using FatTiger.Blog.Application.Contracts.Blog.Params;
using FatTiger.Blog.Domain.Blog;
using FatTiger.Blog.Domain.Blog.Repositories;
using FatTiger.Blog.ToolKits.Base;
using FatTiger.Blog.ToolKits.Extensions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Nito.AsyncEx;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FatTiger.Blog.Domain.Shared.FatTigerBlogConsts;

namespace FatTiger.Blog.Application.Blog.Impl
{
    public partial class BlogService : ServiceBase,IBlogService
    {
        private readonly IBlogCacheService _blogCacheService;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IPostTagRepository _postTagRepository;
        private readonly IFriendLinkRepository _friendLinksRepository;

        public BlogService(IBlogCacheService blogCacheService,
                           IPostRepository postRepository,
                           ICategoryRepository categoryRepository,
                           ITagRepository tagRepository,
                           IPostTagRepository postTagRepository,
                           IFriendLinkRepository friendLinksRepository)
        {
            _blogCacheService = blogCacheService;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
            _friendLinksRepository = friendLinksRepository;
        }

    }
}
