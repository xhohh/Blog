﻿using FatTiger.Blog.Application.Contracts;
using FatTiger.Blog.Application.Contracts.Blog;
using FatTiger.Blog.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FatTiger.Blog.ToolKits.Extensions;
using static FatTiger.Blog.Domain.Shared.FatTigerBlogConsts;
using System.Linq;

namespace FatTiger.Blog.Application.Blog.Impl
{
    public partial class BlogService
    {
        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input)
        {
            return await _blogCacheService.QueryPostsAsync(input, async () =>
            {
                var result = new ServiceResult<PagedList<QueryPostDto>>();

                var count = await _postRepository.GetCountAsync();

                var list = _postRepository.OrderByDescending(x => x.CreationTime)
                                          .PageByIndex(input.Page, input.Limit)
                                          .Select(x => new PostBriefDto
                                          {
                                              Title = x.Title,
                                              Url = x.Url,
                                              Year = x.CreationTime.Year,
                                              CreationTime = x.CreationTime.TryToDateTime()
                                          }).GroupBy(x => x.Year)
                                          .Select(x => new QueryPostDto
                                          {
                                              Year = x.Key,
                                              Posts = x.ToList()
                                          }).ToList();

                result.IsSuccess(new PagedList<QueryPostDto>(count.TryToInt(), list));
                return result;
            });
        }


        //BlogService.Post.cs
        /// <summary>
        /// 根据URL获取文章详情
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url)
        {
            return await _blogCacheService.GetPostDetailAsync(url, async () =>
            {
                var result = new ServiceResult<PostDetailDto>();

                var post = await _postRepository.FindAsync(x => x.Url.Equals(url));

                if (null == post)
                {
                    result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("URL", url));
                    return result;
                }

                var category = await _categoryRepository.GetAsync(post.CategoryId);

                var tags = from post_tags in await _postTagRepository.GetListAsync()
                           join tag in await _tagRepository.GetListAsync()
                           on post_tags.TagId equals tag.Id
                           where post_tags.PostId.Equals(post.Id)
                           select new TagDto
                           {
                               TagName = tag.TagName,
                               DisplayName = tag.DisplayName
                           };

                var previous = _postRepository.Where(x => x.CreationTime > post.CreationTime).Take(1).FirstOrDefault();
                var next = _postRepository.Where(x => x.CreationTime < post.CreationTime).OrderByDescending(x => x.CreationTime).Take(1).FirstOrDefault();

                var postDetail = new PostDetailDto
                {
                    Title = post.Title,
                    Author = post.Author,
                    Url = post.Url,
                    Html = post.Html,
                    Markdown = post.Markdown,
                    CreationTime = post.CreationTime.TryToDateTime(),
                    Category = new CategoryDto
                    {
                        CategoryName = category.CategoryName,
                        DisplayName = category.DisplayName
                    },
                    Tags = tags,
                    Previous = previous == null ? null : new PostForPagedDto
                    {
                        Title = previous.Title,
                        Url = previous.Url
                    },
                    Next = next == null ? null : new PostForPagedDto
                    {
                        Title = next.Title,
                        Url = next.Url
                    }
                };

                result.IsSuccess(postDetail);
                return result;
            });
        }
    }
}
