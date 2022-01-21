using MediatR;

namespace Verbum.Application.Verbum.Message.Commands.CreateMessage
{
    public class SendMessageCommand :IRequest<Guid>
    {
        public string? Text { get; set; }
        public Guid Seller { get; set; }
        public Guid UserId { get; set; }

    }
}
