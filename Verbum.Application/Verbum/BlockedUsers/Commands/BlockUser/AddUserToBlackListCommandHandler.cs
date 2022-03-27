using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain;

namespace Verbum.Application.Verbum.BlockedUsers.Commands.BlockUser
{
    public class AddUserToBlackListCommandHandler :IRequestHandler<AddUserToBlackListCommand, Guid>
    {

        private readonly IVerbumDbContext _dbContext;
        private readonly CommonRepository _commonRepository;
        private readonly VerbumHubRepository _verbumHubRepository;

        public AddUserToBlackListCommandHandler(IVerbumDbContext verbumDb, CommonRepository common, VerbumHubRepository verbumHub) => 
            (_dbContext, _commonRepository, _verbumHubRepository) = (verbumDb, common, verbumHub);

        public async Task<Guid> Handle(AddUserToBlackListCommand request, CancellationToken cancellationToken) {

            if (request.UserToBlockId == request.UserId) {
                throw new Exception("User and UserToBlack should not match");
            }
            
            var user = await _dbContext.Users.Include(b => b.UserBlackLists).FirstOrDefaultAsync(u => u.Id == request.UserId,
                cancellationToken);

            if (user == null) {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            await _commonRepository.DeletingContactsWhenBlockingUser(request.UserToBlockId, request.UserId, cancellationToken);


            var UserToBlackList = new UserBlackList
            {
                Id = Guid.NewGuid(),
                Contact = request.UserToBlockId,
                UserId = request.UserId
            };

            await _dbContext.UserBlackLists.AddAsync(UserToBlackList);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await _verbumHubRepository.NotificateUserForBlocking(request.UserToBlockId, request.UserId);

            return UserToBlackList.Id;
        }
    }
}
