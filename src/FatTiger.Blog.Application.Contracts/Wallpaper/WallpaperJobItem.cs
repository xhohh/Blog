using FatTiger.Blog.Domain.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Contracts.Wallpaper
{
    public class WallpaperJobItem<T>
    {
        /// <summary>
        /// <see cref="Result"/>
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public WallpaperEnum Type { get; set; }
    }
}
