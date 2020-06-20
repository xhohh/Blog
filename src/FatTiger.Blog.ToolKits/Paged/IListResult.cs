using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.ToolKits.Paged
{
    public interface IListResult<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        IReadOnlyList<T> Item { get; set; }
    }
}
