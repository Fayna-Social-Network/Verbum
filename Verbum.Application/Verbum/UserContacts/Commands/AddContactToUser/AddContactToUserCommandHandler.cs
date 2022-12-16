using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain;
using Verbum.Domain.Notifications;

namespace Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser
{
    public class AddContactToUserCommandHandler :IRequestHandler<AddContactToUserCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly CommonRepository _commonRepository;
        private readonly VerbumHubRepository _verbumHubRepository;

        public AddContactToUserCommandHandler(IVerbumDbContext dbContext, CommonRepository commonRepository, VerbumHubRepository verbumHub) => 
                (_dbContext, _commonRepository, _verbumHubRepository) = (dbContext, commonRepository, verbumHub);

        public async Task<Guid> Handle(AddContactToUserCommand request, CancellationToken cancellationToken) {

            await _commonRepository.IsUserInBlackList(request.UserId, request.Contact);
            await _commonRepository.IsUserInBlackList(request.Contact, request.UserId);

            var contactBlackLists = await _dbContext.UserBlackLists.Where(b => b.UserId == request.Contact).ToListAsync();

            if (contactBlackLists != null)
            {
                foreach (var BlackList in contactBlackLists)
                {
                    if (BlackList.Contact == request.UserId)
                    {
                        throw new Exception($"{request.UserId} is blocked by User");
                    }
                }
            }

            var contact = new UserContact
            {
                Id = Guid.NewGuid(),
                Contact = request.Contact,
                UserId = request.UserId,
                Name = request.Name,
                GroupId = request.GroupId
            };

            var notify = new Notification
            {
                Id = Guid.NewGuid(),
                Type = "AddUserToContact",
                Author = request.Contact,
                Message = "User add you to contacts",
                ObjectId = request.Contact,
                isRead = false,
                timestamp = DateTime.UtcNow,
                UserId = request.UserId
            };

            await _verbumHubRepository.SendNotificationToUser(notify);
            await _dbContext.notifications.AddAsync(notify, cancellationToken);
          
            await _dbContext.UserContacts.AddAsync(contact, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return contact.Id;
        }
    }
}
