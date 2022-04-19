using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.StickerData.Commands.DeleteStickersGroupFromUser
{
    public class DeleteStickerGroupFromUserCommandHandler : IRequestHandler<DeleteStickersGroupFromUserCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public DeleteStickerGroupFromUserCommandHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<Unit> Handle(DeleteStickersGroupFromUserCommand request, CancellationToken cancellationToken) {
            var user = await _dbContext.Users
                .Include(u => u.stickersGroups)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null) {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            var stickerGroup = await _dbContext.stickersGroups.FirstOrDefaultAsync(g => g.Id == request.StickerGroupId, cancellationToken);

            if (stickerGroup == null) {
                throw new NotFoundException(nameof(StickersGroup), request.StickerGroupId);
            }

            user.stickersGroups?.Remove(stickerGroup);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
