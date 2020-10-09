using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Contracts.Blog
{
    public class PostBriefForAdminDto : PostBriefDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
    }
}
