using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.BlockedUsers.Commands.BlockUser
{
    public class AddUserToBlackListCommandHandler :IRequestHandler<AddUserToBlackListCommand, Guid>
    {

        private readonly IVerbumDbContext _dbContext;

        public AddUserToBlackListCommandHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<Guid> Handle(AddUserToBlackListCommand request, CancellationToken cancellationToken) {

            if (request.UserToBlockId == request.UserId) {
                throw new Exception("User and UserToBlack should not match");
            }
            
            var user = await _dbContext.Users.Include(b => b.UserBlackLists).FirstOrDefaultAsync(u => u.Id == request.UserId,
                cancellationToken);

            if (user == null) {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            var blockUserContacts = await _dbContext.UserContacts.Where(c => c.GroupId == request.UserToBlockId).ToListAsync();

            if (blockUserContacts != null) {
                foreach (var contact in blockUserContacts) {
                    if (contact.Contact == request.UserId) {
                        _dbContext.UserContacts.Remove(contact);
                    }
                }
            }

            var UserToBlackList = new UserBlackList
            {
                Id = Guid.NewGuid(),
                Contact = request.UserToBlockId,
                UserId = request.UserId
            };

            await _dbContext.UserBlackLists.AddAsync(UserToBlackList);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return UserToBlackList.Id;
        }
    }
}
