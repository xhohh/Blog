using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Contracts.Blog
{
    public class QueryPostForAdminDto:QueryPostDto
    {
        public new IEnumerable<PostBriefForAdminDto> Posts { get; set; }
    }
}
