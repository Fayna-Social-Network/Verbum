using MediatR;

namespace Verbum.Application.UserGrops.UserGroup.Commands.OwnerAddUserToGroup
{
    public class OwnerAddUserToGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public Guid OwnerGroupId { get; set; }
    }
}
