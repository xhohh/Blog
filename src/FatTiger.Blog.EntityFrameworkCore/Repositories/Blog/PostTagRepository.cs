using FatTiger.Blog.Domain.Blog;
using FatTiger.Blog.Domain.Blog.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FatTiger.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class PostTagRepository:EfCoreRepository<FatTigerBlogDbContext,PostTag,int>,IPostTagRepository
    {
        public PostTagRepository(IDbContextProvider<FatTigerBlogDbContext> dbContextProvider):base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<PostTag> postTags)
        {
            await DbContext.Set<PostTag>().AddRangeAsync(postTags);
            await DbContext.SaveChangesAsync();
        }
    }
}
