﻿using FatTiger.Blog.Domain.Wallpaper.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FatTiger.Blog.EntityFrameworkCore.Repositories.Wallpaper
{
    public class WallpaperRepository :EfCoreRepository<FatTigerBlogDbContext, Domain.Wallpaper.Wallpaper, Guid>,IWallpaperRepository
    {
        public WallpaperRepository(IDbContextProvider<FatTigerBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="wallpapers"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Domain.Wallpaper.Wallpaper> wallpapers)
        {
            await DbContext.Set<Domain.Wallpaper.Wallpaper>().AddRangeAsync(wallpapers);
            await DbContext.SaveChangesAsync();
        }
    }
}
