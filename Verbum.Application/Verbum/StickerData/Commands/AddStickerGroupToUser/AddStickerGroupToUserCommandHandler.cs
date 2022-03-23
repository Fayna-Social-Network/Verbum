using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.StickerData.Commands.AddStickerGroupToUser
{
    public class AddStickerGroupToUserCommandHandler :IRequestHandler<AddStickerGroupToUserCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public AddStickerGroupToUserCommandHandler(IVerbumDbContext verbumDbContext) => _dbContext = verbumDbContext;

        public async Task<Unit> Handle(AddStickerGroupToUserCommand request, CancellationToken cancellationToken) {
            var user = await _dbContext.Users.Include(sg => sg.stickersGroups)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null) {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            var stickersGroup = await _dbContext.stickersGroups
                .FirstOrDefaultAsync(g => g.Id == request.StickerGroupId, cancellationToken);
            if (stickersGroup == null) {
                throw new NotFoundException(nameof(StickersGroup), request.StickerGroupId);
            }

            user.stickersGroups?.Add(stickersGroup);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
