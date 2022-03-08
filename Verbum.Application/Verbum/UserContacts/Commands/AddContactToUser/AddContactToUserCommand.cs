using MediatR;

namespace Verbum.Application.Verbum.UserContacts.Commands.AddContactToUser
{
    public class AddContactToUserCommand :IRequest<Guid>
    {
        public Guid Contact { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Group { get; set; }
    }
}
