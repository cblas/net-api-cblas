using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly social_media_dbContext _dbContext;
        public UserRepository(social_media_dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> Get()
        {
            var user = await _dbContext.User.ToListAsync();
            return user;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(user => user.Id == id);
            return user;
        }
    }
}
