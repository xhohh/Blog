using FatTiger.Blog.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace FatTiger.Blog
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(FatTigerBlogApplicationModule)
    )]
    public class FatTigerBlogHttpApiModule : AbpModule
    {
        
    }
}
