using Microsoft.AspNetCore.SignalR;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Application.UserGrops.Repositories.dtos;
using Verbum.Domain;
using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Application.UserGrops.Repositories
{
    public class UserGroupsHubRepository
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IHubContext<VerbumHub> _hubContext;

        public UserGroupsHubRepository(IVerbumDbContext dbContext, IHubContext<VerbumHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
        }

        public async Task NotificateUserInGroupForNewMessage(Group group, Guid groupThemeId, Domain.Groups.GroupsMessages.GroupMessage messages) 
        {
            var notification = new NotificateUsersForMessageDto { groupId = group.id, groupThemeId = groupThemeId, message = messages };

            if (group.users != null) {

                foreach (var user in group.users)
                {
                    if (user.Id == messages.Seller) { continue; }

                    if (user.IsOnline)
                    {
                        await _hubContext.Clients.Client(user.HubConnectionId!).SendAsync("NotificateUserInGroupsForMessage", notification);
                    }
                }
            }
        } 
    }
}
