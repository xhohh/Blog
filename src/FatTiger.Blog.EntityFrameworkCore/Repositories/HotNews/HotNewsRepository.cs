using FatTiger.Blog.Domain.HotNews.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FatTiger.Blog.EntityFrameworkCore.Repositories.HotNews
{
    public class HotNewsRepository : EfCoreRepository<FatTigerBlogDbContext,Domain.HotNews.HotNews,Guid>,IHotNewsRepository
    {
        public HotNewsRepository(IDbContextProvider<FatTigerBlogDbContext> dbContextProvider):base(dbContextProvider)
        {

        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="hotNews"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Domain.HotNews.HotNews> hotNews)
        {
            await DbContext.Set<Domain.HotNews.HotNews>().AddRangeAsync(hotNews);
            await DbContext.SaveChangesAsync();
        }
    }
}
