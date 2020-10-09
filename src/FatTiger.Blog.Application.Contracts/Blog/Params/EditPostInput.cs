using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Contracts.Blog.Params
{
    public class EditPostInput : PostDto
    {
        /// <summary>
        /// 标签
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}
