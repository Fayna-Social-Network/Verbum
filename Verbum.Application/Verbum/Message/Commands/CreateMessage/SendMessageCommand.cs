using MediatR;

namespace Verbum.Application.Verbum.Message.Commands.CreateMessage
{
    public class SendMessageCommand :IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public Guid Seller { get; set; }
        public Guid UserId { get; set; } 
        public Guid ChatId { get; set; }

    }
}
