using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> Get();
        Task<Post> GetById(int id);
        Task Add(Post post);
        Task<bool> Update(Post post);
        Task<bool> Delete(int id);
    }
}