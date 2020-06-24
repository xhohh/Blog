using FatTiger.Blog.BackgroundJobs.Jobs.Hangfire;
using Hangfire;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.BackgroundJobs
{
    public static class FatTigerBlogBackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider service)
        {
            var job = service.GetService<HangfireTestJob>();

            RecurringJob.AddOrUpdate("定时任务测试", () => job.ExecuteAsync(), CronType.Minute());

        }
    }
}
