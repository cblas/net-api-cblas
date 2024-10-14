using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly social_media_dbContext _dbContext;
        public PostRepository(social_media_dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Post>> Get()
        {
            var post = await _dbContext.Post.ToListAsync();
            return post;
        }

        public async Task<Post> GetById(int id)
        {
            var post = await _dbContext.Post.FirstOrDefaultAsync(post => post.Id == id);
            return post;
        }

        public async Task Add(Post post)
        {
            await _dbContext.Post.AddAsync(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(Post post)
        {
            var postById = await GetById(post.Id);
            postById.Description = post.Description;
            postById.CreatedAt = post.CreatedAt;
            postById.UrlImage = post.UrlImage;
            
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var postById = await GetById(id);
            _dbContext.Post.Remove(postById);

            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
