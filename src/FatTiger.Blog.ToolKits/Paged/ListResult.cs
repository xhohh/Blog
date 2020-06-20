using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.ToolKits.Paged
{
    public class ListResult<T> : IListResult<T>
    {
        IReadOnlyList<T> item;

        public IReadOnlyList<T> Item
        {
            get => item ??= new List<T>();
            set => item = value;
        }

        public ListResult()
        {

        }

        public ListResult(IReadOnlyList<T> item)
        {
            Item = item;
        }
    }
}
