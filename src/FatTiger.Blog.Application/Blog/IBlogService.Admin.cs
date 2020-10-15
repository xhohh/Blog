﻿using FatTiger.Blog.Application.Contracts;
using FatTiger.Blog.Application.Contracts.Blog;
using FatTiger.Blog.Application.Contracts.Blog.Params;
using FatTiger.Blog.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatTiger.Blog.Application.Blog
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 分页查询文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedList<QueryPostForAdminDto>>> QueryPostsForAdminAsync(PagingInput input);


        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> InsertPostAsync(EditPostInput input);

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> UpdatePostAsync(int id, EditPostInput input);

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult> DeletePostAsync(int id);


        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult<PostForAdminDto>> GetPostForAdminAsync(int id);

        #region Categories

        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryCategoryForAdminDto>>> QueryCategoriesForAdminAsync();

        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> InsertCategoryAsync(EditCategoryInput input);

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> UpdateCategoryAsync(int id, EditCategoryInput input);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult> DeleteCategoryAsync(int id);

        #endregion Categories


        #region Tags

        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryTagForAdminDto>>> QueryTagsForAdminAsync();

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> InsertTagAsync(EditTagInput input);

        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> UpdateTagAsync(int id, EditTagInput input);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult> DeleteTagAsync(int id);

        #endregion Tags

        #region FriendLinks

        /// <summary>
        /// 查询友链列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryFriendLinkForAdminDto>>> QueryFriendLinksForAdminAsync();

        /// <summary>
        /// 新增友链
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> InsertFriendLinkAsync(EditFriendLinkInput input);

        /// <summary>
        /// 更新友链
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> UpdateFriendLinkAsync(int id, EditFriendLinkInput input);

        /// <summary>
        /// 删除友链
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult> DeleteFriendLinkAsync(int id);

        #endregion FriendLinks
    }
}
