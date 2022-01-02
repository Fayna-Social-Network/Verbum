using MediatR;

namespace Verbum.Application.Verbum.Commands.CreateMessage
{
    public class CreateMessageCommand :IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string? Text { get; set; }
    }
}
