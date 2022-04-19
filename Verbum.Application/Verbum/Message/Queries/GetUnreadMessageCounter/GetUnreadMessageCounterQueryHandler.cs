using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.Verbum.Message.Queries.GetUnreadMessageCounter
{
    public class GetUnreadMessageCounterQueryHandler :IRequestHandler<GetUnreadMessageCounterQuery, int>
    {
        private readonly IVerbumDbContext _dbContext;

        public GetUnreadMessageCounterQueryHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<int> Handle(GetUnreadMessageCounterQuery request, CancellationToken cancellationToken) {

            var messages = await _dbContext.Messages
               .Where(m => m.UserId == request.UserId && m.Seller == request.ContactId)
               .ToListAsync();

            var UnreadMessages = messages.FindAll(m => m.IsRead == false);

            return UnreadMessages.Count();
        } 
    }
}
