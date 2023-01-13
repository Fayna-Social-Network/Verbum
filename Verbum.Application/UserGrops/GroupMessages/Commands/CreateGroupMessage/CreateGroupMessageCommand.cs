using MediatR;

namespace Verbum.Application.UserGrops.GroupMessage.Commands.CreateGroupMessage
{
    public class CreateGroupMessageCommand : IRequest<Guid>
    {
        public Guid SellerId { get; set; }
        public Guid GroupId { get; set; }
        public Guid GroupThemeId { get; set; }
        public string? Text { get; set; }
    }
}
