using FatTiger.Blog.Domain.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Contracts.HotNews
{
    public class HotNewsJobItem<T>
    {
        /// <summary>
        /// <see cref="Result"/>
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public HotNewsEnum Source { get; set; }
    }
}