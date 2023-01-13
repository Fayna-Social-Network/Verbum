using MediatR;

namespace Verbum.Application.UserGrops.UserGroup.Commands.CreateUserGroup
{
    public class CreateUserGroupCommand : IRequest<Guid>
    {
        public string? GroupName { get; set; }
        public string? GroupAvatarPath { get; set; } 
        public string? GroupTheme { get; set; }
        public bool isClosedGroup { get; set; }
        public Guid UserId { get; set; }
    }
}
