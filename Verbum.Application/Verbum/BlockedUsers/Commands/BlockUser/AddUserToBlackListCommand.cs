using MediatR;

namespace Verbum.Application.Verbum.BlockedUsers.Commands.BlockUser
{
    public class AddUserToBlackListCommand :IRequest<Guid>
    {
        public Guid UserToBlockId { get; set; }
        public Guid UserId { get; set; }
    }
}
