using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using FatTiger.Blog.Domain;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}
