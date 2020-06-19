using Volo.Abp.Domain.Repositories;

namespace FatTiger.Blog.Domain.Blog.Repositories
{
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}
