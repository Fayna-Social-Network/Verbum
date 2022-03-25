using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.Verbum.Repositories
{
    public class CommonRepository
    {
        private readonly IVerbumDbContext _dbContext;

        public CommonRepository(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task IsUserInBlackList(Guid UserId, Guid UserToCheckId) {
            
            var userBlackList = await _dbContext.UserBlackLists.Where(b => b.UserId == UserId).ToListAsync();

            if (userBlackList != null)
            {
                foreach (var blackList in userBlackList)
                {
                    if (blackList.Contact == UserToCheckId)
                    {
                        throw new Exception($"{UserToCheckId} is blocked by User");
                    }
                }
            }

        }
    }
}
