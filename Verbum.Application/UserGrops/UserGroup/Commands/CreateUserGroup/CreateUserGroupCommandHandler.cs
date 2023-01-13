using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Application.UserGrops.UserGroup.Commands.CreateUserGroup
{
    public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;

        public CreateUserGroupCommandHandler(IVerbumDbContext dbContext) { _dbContext = dbContext; }

        public async Task<Guid> Handle(CreateUserGroupCommand request, CancellationToken cancellationToken) {

            var query = await _dbContext.groups.FirstOrDefaultAsync(g => g.GroupName == request.GroupTheme);
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (query != null)
            {
                throw new Exception("This group name is already exits");
            }

            if(user == null) 
            {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            var group = new Group
            {
                id = Guid.NewGuid(),
                GroupAvatarPath = request.GroupAvatarPath,
                GroupName = request.GroupName,
                isGroupClosed = request.isClosedGroup,
                isBlockedGroup = false,
                UserId = request.UserId,
                users = new List<VerbumUser> { user }
            };

           

            var groupTheme = new GroupsThemes
            {
                Id = Guid.NewGuid(),
                Name = request.GroupTheme,
                GroupId = group.id
            };

            await _dbContext.groups.AddAsync(group, cancellationToken);
            await _dbContext.groupsThemes.AddAsync(groupTheme, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return group.id;
        } 
    }
}
