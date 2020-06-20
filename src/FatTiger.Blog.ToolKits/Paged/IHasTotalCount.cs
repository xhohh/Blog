using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.ToolKits.Paged
{
    public interface IHasTotalCount
    {
        /// <summary>
        /// 总数
        /// </summary>
        int Total { get; set; }
    }
}
