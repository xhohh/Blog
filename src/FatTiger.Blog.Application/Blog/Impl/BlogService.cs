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

        public async Task<ServiceResult> InsertPostAsync(EditPostInput input)
        {
            var result = new ServiceResult();

            var post = ObjectMapper.Map<EditPostInput, Post>(input);
            post.Url = $"{post.CreationTime.ToString(" yyyy MM dd ").Replace(" ", "/")}{post.Url}/";
            await _postRepository.InsertAsync(post);

            var tags = await _tagRepository.GetListAsync();

            var newTags = input.Tags
                .Where(item => !tags.Any(x => x.TagName.Equals(item)))
                .Select(item => new Tag
                {
                    TagName=item,
                    DisplayName = item
                });
            await _tagRepository.BulkInsertAsync(newTags);

            var postTags = input.Tags.Select(item => new PostTag
            {
                PostId = post.Id,
                TagId = _tagRepository.FirstOrDefault(x=>x.TagName==item).Id
            });

            await _postTagRepository.BulkInsertAsync(postTags);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);

            return result;
        }

        public async Task<ServiceResult<PagedList<QueryPostForAdminDto>>> QueryPostsForAdminAsync(PagingInput input)
        {
            var result = new ServiceResult<PagedList<QueryPostForAdminDto>>();

            var count = await _postRepository.GetCountAsync();

            var list = _postRepository.OrderByDescending(x => x.CreationTime)
                                      .PageByIndex(input.Page, input.Limit)
                                      .Select(x => new PostBriefForAdminDto
                                      {
                                          Id = x.Id,
                                          Title = x.Title,
                                          Url = x.Url,
                                          Year = x.CreationTime.Year,
                                          CreationTime = x.CreationTime.TryToDateTime()
                                      })
                                      .GroupBy(x => x.Year)
                                      .Select(x => new QueryPostForAdminDto
                                      {
                                          Year = x.Key,
                                          Posts = x.ToList()
                                      }).ToList();

            result.IsSuccess(new PagedList<QueryPostForAdminDto>(count.TryToInt(), list));
            return result;
        }

        public async Task<ServiceResult> UpdatePostAsync(int id, EditPostInput input)
        {
            var result = new ServiceResult();

            var post = await _postRepository.GetAsync(id);
            post.Title = input.Title;
            post.Author = input.Author;
            post.Url = $"{input.CreationTime.ToString(" yyyy MM dd ").Replace(" ", "/")}{input.Url}/";
            post.Html = input.Html;
            post.Markdown = input.Markdown;
            post.CreationTime = input.CreationTime;
            post.CategoryId = input.CategoryId;

            await _postRepository.UpdateAsync(post);

            var tags = await _tagRepository.GetListAsync();

            var oldPostTags = from post_tags in await _postTagRepository.GetListAsync()
                              join tag in await _tagRepository.GetListAsync()
                              on post_tags.TagId equals tag.Id
                              where post_tags.PostId.Equals(post.Id)
                              select new
                              {
                                  post_tags.Id,
                                  tag.TagName
                              };

            var removedIds = oldPostTags.Where(item => !input.Tags.Any(x => x == item.TagName) &&
                tags.Any(t => t.TagName == item.TagName))
                .Select(item => item.Id);
            await _postTagRepository.DeleteAsync(x => removedIds.Contains(x.Id));

            var newTags = input.Tags
                       .Where(item => !tags.Any(x => x.TagName == item))
                       .Select(item => new Tag
                       {
                           TagName = item,
                           DisplayName = item
                       });
            await _tagRepository.BulkInsertAsync(newTags);

            var postTags = input.Tags
                                .Where(item => !oldPostTags.Any(x => x.TagName == item))
                                .Select(item => new PostTag
                                {
                                    PostId = id,
                                    TagId = _tagRepository.FirstOrDefault(x => x.TagName == item).Id
                                });
            await _postTagRepository.BulkInsertAsync(postTags);

            result.IsSuccess(ResponseText.UPDATE_SUCCESS);
            return result;

        }


        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResult> DeletePostAsync(int id)
        {
            var result = new ServiceResult();

            var post = await _postRepository.GetAsync(id);
            if (null == post)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("Id", id));
                return result;
            }

            await _postRepository.DeleteAsync(id);
            await _postTagRepository.DeleteAsync(x => x.PostId == id);

            result.IsSuccess(ResponseText.DELETE_SUCCESS);
            return result;
        }

        //public async Task<ServiceResult<string>> InsertPostAsync(PostDto dto)
        //{
        //    var result = new ServiceResult<string>();

        //    var entity = ObjectMapper.Map<PostDto, Post>(dto);

        //    var post = await _postRepository.InsertAsync(entity);
        //    if (post == null)
        //    {
        //        result.IsFailed("添加失败");
        //        return result;
        //    }

        //    result.IsSuccess("添加成功");
        //    return result;
        //}

        //public async Task<ServiceResult> DeletePostAsync(int id)
        //{
        //    var result = new ServiceResult();

        //    await _postRepository.DeleteAsync(id);

        //    return result;
        //}

        //public async Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto)
        //{
        //    var result = new ServiceResult<string>();

        //    var post = await _postRepository.GetAsync(id);
        //    if (post == null)
        //    {
        //        result.IsFailed("文章不存在");
        //        return result;
        //    }

        //    post.Title = dto.Title;
        //    post.Author = dto.Author;
        //    post.Url = dto.Url;
        //    post.Html = dto.Html;
        //    post.Markdown = dto.Markdown;
        //    post.CategoryId = dto.CategoryId;
        //    post.CreationTime = dto.CreationTime;

        //    await _postRepository.UpdateAsync(post);


        //    result.IsSuccess("更新成功");
        //    return result;
        //}

        //public async Task<ServiceResult<PostDto>> GetPostAsync(int id)
        //{
        //    var result = new ServiceResult<PostDto>();

        //    var post = await _postRepository.GetAsync(id);
        //    if (post == null)
        //    {
        //        result.IsFailed("文章不存在");
        //        return result;
        //    }

        //    var dto = ObjectMapper.Map<Post, PostDto>(post);

        //    result.IsSuccess(dto);
        //    return result;
        //}
    }
}
