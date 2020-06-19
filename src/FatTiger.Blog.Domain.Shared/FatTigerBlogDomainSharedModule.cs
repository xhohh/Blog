using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace FatTiger.Blog.Domain.Shared
{
    [DependsOn(typeof(AbpIdentityDomainSharedModule))]
    public class FatTigerBlogDomainSharedModule: AbpModule
    {

    }
}
