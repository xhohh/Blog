using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace FatTiger.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(FatTigerBlogFrameworkCoreModule)
    )]
    public class FatTigerBlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {       
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<FatTigerBlogMigrationsDbContext>();
        }
    }
}
