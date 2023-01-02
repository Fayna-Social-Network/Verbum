using MediatR;

namespace Verbum.Application.UserGrops.UserGroup.Commands.DeleteUserGroup
{
    public class DeleteUserGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
