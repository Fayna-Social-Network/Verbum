using MediatR;

namespace Verbum.Application.Verbum.BlockedUsers.Commands.UnBlockUser
{
    public class UnBlockUserCommand :IRequest
    {
        public Guid BlockId { get; set; }
        public Guid UserId { get; set; }
    }
}
