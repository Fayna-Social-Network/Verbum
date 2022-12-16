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

        public async Task<bool> IsUserIsFriends(Guid UserId, Guid FriendId) 
        {
            var userFriends = await _dbContext.UserContacts.Where(u => u.UserId == UserId).ToListAsync();

            if (userFriends != null) 
            {
                foreach (var friend in userFriends) 
                {
                    if(friend.Contact == FriendId) 
                    {
                        return true;
                    }

                }
            }

            return false;
        }             

        public async Task DeletingContactsWhenBlockingUser(Guid blockUserId, Guid UserId, CancellationToken cancellationToken) {
          var blockUserContacts = await _dbContext.UserContacts.Where(b => b.UserId == blockUserId).ToListAsync();

            if (blockUserContacts != null) {
                foreach (var contact in blockUserContacts) {
                    if (contact.Contact == UserId) {
                        _dbContext.UserContacts.Remove(contact);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }
            }

           

            var UserContacts = await _dbContext.UserContacts.Where(c => c.UserId == UserId).ToListAsync();

            if (UserContacts != null) {
                foreach (var contact in UserContacts) {
                    if (contact.Contact == blockUserId) {
                        _dbContext.UserContacts.Remove(contact);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }
            }

           
        }
    }
}
