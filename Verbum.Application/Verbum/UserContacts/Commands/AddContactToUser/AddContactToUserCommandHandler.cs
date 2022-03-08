using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser
{
    public class AddContactToUserCommandHandler :IRequestHandler<AddContactToUserCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;

        public AddContactToUserCommandHandler(IVerbumDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(AddContactToUserCommand request, CancellationToken cancellationToken) {

            var contact = new UserContact
            {
                Id = Guid.NewGuid(),
                Contact = request.Contact,
                UserId = request.UserId,
                Name = request.Name,
                Group = request.Group
            };
          
            await _dbContext.UserContacts.AddAsync(contact, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return contact.Id;
        }
    }
}
