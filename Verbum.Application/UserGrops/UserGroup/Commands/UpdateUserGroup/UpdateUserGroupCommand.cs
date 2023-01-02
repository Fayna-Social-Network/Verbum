using MediatR;

namespace Verbum.Application.UserGrops.UserGroup.Commands.UpdateUserGroup
{
    public class UpdateUserGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public string? NewGroupName { get; set; }
        public bool isClosed { get; set; }
    }
}
