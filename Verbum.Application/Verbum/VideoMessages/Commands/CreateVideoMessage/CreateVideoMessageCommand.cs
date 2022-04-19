using MediatR;

namespace Verbum.Application.Verbum.VideoMessages.Commands.CreateVideoMessage
{
    public class CreateVideoMessageCommand :IRequest<Guid>
    {
        public string VideoPath { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
    }
}
