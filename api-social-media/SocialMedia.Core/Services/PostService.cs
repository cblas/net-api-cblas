using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> Get()
        {
           return await _postRepository.Get();
        }

        public async Task<Post> GetById(int id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task Add(Post post)
        {
            await _postRepository.Add(post);
        }

        public async Task<bool> Update(Post post)
        {
            return await _postRepository.Update(post);
        }

        public async Task<bool> Delete(int id)
        {
            return await _postRepository.Delete(id);
        }
    }
}
