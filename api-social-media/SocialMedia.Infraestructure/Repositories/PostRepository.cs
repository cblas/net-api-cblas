using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
