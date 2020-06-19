using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace FatTiger.Blog.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class FatTigerBlogDomainModule : AbpModule
    {

    }
}
