using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Contracts.Blog
{
    public class PostForPagedDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }
    }
}
