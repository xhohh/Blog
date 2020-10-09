using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using FatTiger.Blog.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;

namespace FatTiger.Blog.Application.Caching
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(FatTigerBlogDomainModule)
    )]
    public class FatTigerBlogApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
                //options.InstanceName
                //options.ConfigurationOptions
            });

            var csredis = new CSRedis.CSRedisClient(AppSettings.Caching.RedisConnectionString);
            RedisHelper.Initialization(csredis);

            context.Services.AddSingleton<IDistributedCache>(new CSRedisCache(RedisHelper.Instance));
        }


    }
}
