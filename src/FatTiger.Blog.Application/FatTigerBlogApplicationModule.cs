using FatTiger.Blog.Application.Caching;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace FatTiger.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(FatTigerBlogApplicationCachingModule)
    )]
    public class FatTigerBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
