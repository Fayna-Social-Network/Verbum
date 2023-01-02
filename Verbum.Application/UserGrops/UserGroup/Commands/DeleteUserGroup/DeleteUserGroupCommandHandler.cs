using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;

namespace Verbum.Application.UserGrops.UserGroup.Commands.DeleteUserGroup
{
    public class DeleteUserGroupCommandHandler : IRequestHandler<DeleteUserGroupCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public DeleteUserGroupCommandHandler(IVerbumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _dbContext.groups.FirstOrDefaultAsync(g => g.id == request.GroupId);

            if (group == null) 
            {
                throw new NotFoundException(nameof(group), request.GroupId);
            }

            if(group.UserId != request.UserId) 
            {
                throw new UserIsNotOwnerException();
            }

             _dbContext.groups.Remove(group);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
