using Volo.Abp.Domain.Repositories;

namespace FatTiger.Blog.Domain.Blog.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
