using FatTiger.Blog.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace FatTiger.Blog.Domain
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(FatTigerBlogDomainSharedModule)
        )]
    public class FatTigerBlogDomainModule : AbpModule
    {

    }
}
