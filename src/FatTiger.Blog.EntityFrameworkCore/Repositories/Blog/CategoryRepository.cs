using FatTiger.Blog.Domain.Blog;
using FatTiger.Blog.Domain.Blog.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FatTiger.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class CategoryRepository:EfCoreRepository<FatTigerBlogDbContext,Category,int>,ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<FatTigerBlogDbContext> dbContextProvider):base(dbContextProvider)
        {

        }
    }
}
