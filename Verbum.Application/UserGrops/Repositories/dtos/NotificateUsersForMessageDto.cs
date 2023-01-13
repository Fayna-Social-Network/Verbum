using Verbum.Domain.Groups.GroupsMessages;

namespace Verbum.Application.UserGrops.Repositories.dtos
{
    public class NotificateUsersForMessageDto
    {
        public Guid groupId { get; set; }
        public Guid groupThemeId { get; set; }
        public Domain.Groups.GroupsMessages.GroupMessage? message { get; set; }
    }
}
