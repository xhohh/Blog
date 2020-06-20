
using FatTiger.Blog.Application.Contracts.Blog;
using FatTiger.Blog.ToolKits.Base;
using System.Threading.Tasks;

namespace FatTiger.Blog.Application.Blog
{
    public interface IBlogService
    {

        Task<ServiceResult<string>> InsertPostAsync(PostDto dto);


        Task<ServiceResult> DeletePostAsync(int id);


        Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto);


        Task<ServiceResult<PostDto>> GetPostAsync(int id);
    }
}
