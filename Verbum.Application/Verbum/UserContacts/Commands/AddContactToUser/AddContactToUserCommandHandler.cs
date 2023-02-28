using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain;
using Verbum.Domain.ChatOnes;
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

            var userContact = await _dbContext.UserContacts.FirstOrDefaultAsync(c => c.Contact == request.UserId && c.UserId == request.Contact);

            Guid userContactId = Guid.NewGuid();

           
            if(userContact == null) 
            {
                var chat = new Chat
                {
                    Id = Guid.NewGuid()
                };

                var contact = new UserContact
                {
                    Id = userContactId,
                    Contact = request.Contact,
                    UserId = request.UserId,
                    Name = request.Name,
                    GroupId = request.GroupId,
                    IsMuted = false,
                    Favorites = false,
                    ContactBackGroundImage = "",
                    ChatId = chat.Id
                };

                await _dbContext.chats.AddAsync(chat, cancellationToken);
                await _dbContext.UserContacts.AddAsync(contact, cancellationToken);

            } else 
            
            {
                var contact = new UserContact
                {
                    Id = userContactId,
                    Contact = request.Contact,
                    UserId = request.UserId,
                    Name = request.Name,
                    GroupId = request.GroupId,
                    IsMuted = false,
                    Favorites = false,
                    ContactBackGroundImage = "",
                    ChatId = userContact.ChatId
                };

                await _dbContext.UserContacts.AddAsync(contact, cancellationToken);
            }

            var notify = new Notification
            {
                Id = Guid.NewGuid(),
                Type = "AddUserToContact",
                Author = request.UserId,
                Message = "User add you to contacts",
                ObjectId = request.UserId,
                isRead = false,
                timestamp = DateTime.UtcNow,
                UserId = request.Contact
            };

            await _verbumHubRepository.SendNotificationToUser(notify);
            await _dbContext.notifications.AddAsync(notify, cancellationToken);
          
            await _dbContext.SaveChangesAsync(cancellationToken);

            return userContactId;
        }
    }
}
