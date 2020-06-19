using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using FatTiger.Blog.Domain;

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
            base.ConfigureServices(context);
        }
    }
}
