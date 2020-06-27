using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FatTiger.Blog.Domain.HotNews.Repositories
{
    public interface IHotNewsRepository : IRepository<HotNews, Guid>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="hotNews"></param>
        /// <returns></returns>
        Task BulkInsertAsync(IEnumerable<HotNews> hotNews);
    }
}
