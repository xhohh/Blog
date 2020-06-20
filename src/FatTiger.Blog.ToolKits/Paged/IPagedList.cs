using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.ToolKits.Paged
{
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {

    }
}
