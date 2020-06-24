using Hangfire;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using FatTiger.Blog.BackgroundJobs.Jobs.Wallpapers;

namespace FatTiger.Blog.BackgroundJobs
{
    public static class FatTigerBlogBackgroundJobsExtensions
    {
        public static void UseWallpaperJob(this IServiceProvider service)
        {
            var job = service.GetService<WallpaperJob>();
            RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 3));
        }
    }
}
