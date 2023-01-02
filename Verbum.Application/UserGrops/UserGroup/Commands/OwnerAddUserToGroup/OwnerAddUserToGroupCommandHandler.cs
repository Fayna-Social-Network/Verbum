using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.UserGrops.UserGroup.Commands.OwnerAddUserToGroup
{
    public class OwnerAddUserToGroupCommandHandler :IRequestHandler<OwnerAddUserToGroupCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public OwnerAddUserToGroupCommandHandler(IVerbumDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<Unit> Handle(OwnerAddUserToGroupCommand request, CancellationToken cancellationToken) 
        {
            var group = await _dbContext.groups.Include(g => g.users).FirstOrDefaultAsync(g => g.id == request.GroupId);
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

            if(group == null) 
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            if(user == null) 
            {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            if (group.UserId != request.OwnerGroupId) 
            {
                throw new UserIsNotOwnerException();
            }

            group.users?.Add(user);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        
        } 
    }
}
