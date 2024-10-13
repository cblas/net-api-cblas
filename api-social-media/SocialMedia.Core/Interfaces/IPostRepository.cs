using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> Get();
        Task<Post> GetById(int id);
        Task Add(Post post);
    }
}
