using MediatR;

namespace Verbum.Application.Verbum.BlockedUsers.Queries.IsUserBlockedMe
{
    public class IsUserBlockedMeQuery : IRequest<isBlockedVm>
    {
        public Guid CheckUserId { get; set; }
        public Guid UserId { get; set; }
    }
}
