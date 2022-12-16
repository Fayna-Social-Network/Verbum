using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain;
using Verbum.Domain.Groups.GroupsMessages;
using Verbum.Domain.Notifications;

namespace Verbum.Application.UserGrops.UserGroup.Commands.AddUserToGroup
{
    public class AddUserToGroupCommandHandler : IRequestHandler<AddUserToGroupCommand>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public AddUserToGroupCommandHandler(IVerbumDbContext dbContext, VerbumHubRepository verbumHubRepository) 
        { (_dbContext, _verbumHubRepository) = (dbContext, verbumHubRepository); }

        public async Task<Unit> Handle(AddUserToGroupCommand requst, CancellationToken cancellationToken)
        {
            var group = await _dbContext.groups.Include(g => g.users).FirstOrDefaultAsync(g => g.id == requst.GroupId);

            if (group == null)
            {
                throw new NotFoundException(nameof(Group), requst.GroupId);
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == requst.UserId);

            if (user == null)
            {
                throw new NotFoundException(nameof(VerbumUser), requst.UserId);
            }

            if (group.isGroupClosed) 
            {
                var notify = new Notification
                {
                    Id = Guid.NewGuid(),
                    Type = "addUserToGroup",
                    Author = user.Id,
                    Message = "User wants to be added to your group",
                    ObjectId = group.id,
                    isRead = false,
                    timestamp = DateTime.Now,
                    UserId = group.UserId
                };

                await _verbumHubRepository.SendNotificationToUser(notify);
                await _dbContext.notifications.AddAsync(notify);
                await _dbContext.SaveChangesAsync(cancellationToken);
               
                return Unit.Value;
            }
            else 
            {
                group.users?.Add(user);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
               
            }
        }    
    }
}
