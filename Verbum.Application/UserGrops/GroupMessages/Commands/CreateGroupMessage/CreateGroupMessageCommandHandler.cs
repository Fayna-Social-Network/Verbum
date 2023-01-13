using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Application.UserGrops.Repositories;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Application.UserGrops.GroupMessage.Commands.CreateGroupMessage
{
    public class CreateGroupMessageCommandHandler : IRequestHandler<CreateGroupMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly CommonRepository _common;
        private readonly UserGroupsHubRepository _userGroupsHub;

        public CreateGroupMessageCommandHandler(IVerbumDbContext dbContext, CommonRepository common, UserGroupsHubRepository userGroupsHub)
        {
            _dbContext = dbContext;
            _common = common;
            _userGroupsHub = userGroupsHub;
        }

        public async Task<Guid> Handle(CreateGroupMessageCommand request, CancellationToken cancellationToken) 
        {
            var group = await _dbContext.groups.Include(g => g.users).FirstOrDefaultAsync(g => g.id == request.GroupId);

            if (group == null) 
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            Guid guid;

            if(group.isGroupClosed) 
            {
                if(group.UserId == request.SellerId) 
                {
                    guid = await SaveGroupMessageToDb(request, group, cancellationToken);

                } else 
                {
                    if (_common.IsTheUserInGroup(group.users!, request.SellerId))
                    {
                        guid = await SaveGroupMessageToDb(request, group, cancellationToken);
                    }
                    else
                    {
                        throw new GroupIsClosedException();
                    }
                }
               
            }

            guid = await SaveGroupMessageToDb(request, group, cancellationToken);

            return guid;
        } 

        private async Task<Guid> SaveGroupMessageToDb(CreateGroupMessageCommand command, Group group, CancellationToken token) 
        {
            var groupMessage = new Domain.Groups.GroupsMessages.GroupMessage
            {
                Id = Guid.NewGuid(),
                Text = command.Text,
                Seller = command.SellerId,
                Timestamp = DateTime.UtcNow,
                IsRead = false,
                GroupThemeId = command.GroupThemeId
            };

            await _userGroupsHub.NotificateUserInGroupForNewMessage(group, command.GroupThemeId, groupMessage);
            await _dbContext.groupMessages.AddAsync(groupMessage, token);
            await _dbContext.SaveChangesAsync(token);

            return groupMessage.Id;
        }
    }
}
