using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.Verbum.BlockedUsers.Queries.IsUserBlockedMe
{
    public class IsUserBlockedMeQueryHandler :IRequestHandler<IsUserBlockedMeQuery, isBlockedVm>
    {
        private readonly IVerbumDbContext _dbContext;
        
        public IsUserBlockedMeQueryHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;


        public async Task<isBlockedVm> Handle(IsUserBlockedMeQuery request, CancellationToken cancellationToken) {
            
            var userBlackList = await _dbContext.UserBlackLists.Where(b => b.UserId == request.CheckUserId).ToListAsync(cancellationToken);

            var Blocked = new isBlockedVm
            {
                IsBlocked = false
            };

            if (userBlackList != null)
            {
                foreach (var blackList in userBlackList)
                {
                    if (blackList.Contact == request.UserId)
                    {
                        Blocked.IsBlocked = true;
                    }
                }
            }

            return Blocked;
        }
    }
}
