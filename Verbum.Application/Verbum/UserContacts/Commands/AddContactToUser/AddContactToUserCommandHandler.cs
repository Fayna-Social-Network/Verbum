using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain;

namespace Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser
{
    public class AddContactToUserCommandHandler :IRequestHandler<AddContactToUserCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly CommonRepository _commonRepository;

        public AddContactToUserCommandHandler(IVerbumDbContext dbContext, CommonRepository commonRepository) => 
                (_dbContext, _commonRepository) = (dbContext, commonRepository);

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
          
            await _dbContext.UserContacts.AddAsync(contact, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return contact.Id;
        }
    }
}
