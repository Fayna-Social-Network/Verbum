using MediatR;

namespace Verbum.Application.UserGrops.UserGroup.Commands.AddUserToGroup
{
    public class AddUserToGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
