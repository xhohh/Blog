using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace FatTiger.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class FatTigerBlogMigrationsDbContextFactory : IDesignTimeDbContextFactory<FatTigerBlogMigrationsDbContext>
    {
        public FatTigerBlogMigrationsDbContext CreateDbContext(string [] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<FatTigerBlogMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("SqlServer"));

            return new FatTigerBlogMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}

