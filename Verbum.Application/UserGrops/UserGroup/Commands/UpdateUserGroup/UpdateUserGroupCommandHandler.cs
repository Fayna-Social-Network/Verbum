using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.UserGrops.UserGroup.Commands.UpdateUserGroup
{
    public class UpdateUserGroupCommandHandler : IRequestHandler<UpdateUserGroupCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public UpdateUserGroupCommandHandler(IVerbumDbContext dbContext ) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserGroupCommand request, CancellationToken cancellationToken ) 
        {
            var group = await _dbContext.groups.FirstOrDefaultAsync(g => g.id == request.GroupId);

            if ( group == null ) 
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            if(group.UserId != request.UserId) 
            {
                throw new UserIsNotOwnerException();
            }

            group.isGroupClosed = request.isClosed;
            group.GroupName = request.NewGroupName;
            group.GroupAvatarPath = request.GroupAvatarPath;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
