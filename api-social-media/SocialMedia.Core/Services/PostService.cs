using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
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
            var user = await _userRepository.GetById(post.IdUser);
            if (user == null)
                throw new Exception("User does not exist");

            if (post.Description.Contains("hacking"))
                throw new Exception("Text do not allowed");

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
