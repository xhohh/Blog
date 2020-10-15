using FatTiger.Blog.Application.Contracts.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Contracts
{
    public class QueryTagForAdminDto:QueryTagDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
    }
}
