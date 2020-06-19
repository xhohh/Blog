using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FatTiger.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class FatTigerBlogMigrationsDbContext:AbpDbContext<FatTigerBlogMigrationsDbContext>
    {
        public FatTigerBlogMigrationsDbContext(DbContextOptions<FatTigerBlogMigrationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
