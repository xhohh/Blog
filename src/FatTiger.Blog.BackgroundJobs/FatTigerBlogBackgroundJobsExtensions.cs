using Hangfire;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using FatTiger.Blog.BackgroundJobs.Jobs.Wallpapers;
using FatTiger.Blog.BackgroundJobs.Jobs.HotNews;
using FatTiger.Blog.BackgroundJobs.Jobs.PuppeteerTest;

namespace FatTiger.Blog.BackgroundJobs
{
    public static class FatTigerBlogBackgroundJobsExtensions
    {
        public static void UseWallpaperJob(this IServiceProvider service)
        {
            var job = service.GetService<WallpaperJob>();
            RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 3));
        }

        /// <summary>
        /// 每日热点数据抓取
        /// </summary>
        /// <param name="context"></param>
        public static void UseHotNewsJob(this IServiceProvider service)
        {
            var job = service.GetService<HotNewsJob>();

            RecurringJob.AddOrUpdate("每日热点数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 2));
        }

        public static void UsePuppeteerTestJob(this IServiceProvider service)
        {
            var job = service.GetService<PuppeteerTestJob>();

            BackgroundJob.Enqueue(() => job.ExecuteAsync());
        }
    }
}
