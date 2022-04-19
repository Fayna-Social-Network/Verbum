using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.BlockedUsers.Commands.UnBlockUser
{
    public class UnBlockUserCommandHandler :IRequestHandler<UnBlockUserCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public UnBlockUserCommandHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<Unit> Handle(UnBlockUserCommand request, CancellationToken cancellationToken) {
            var blockUser = await _dbContext.UserBlackLists.FirstOrDefaultAsync(b => b.Id == request.BlockId, cancellationToken);

            if (blockUser == null || blockUser.UserId != request.UserId) {
                throw new NotFoundException(nameof(UserBlackList), request.BlockId);
            }

            _dbContext.UserBlackLists.Remove(blockUser);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
