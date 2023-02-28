using MediatR;

namespace Verbum.Application.Verbum.Message.Queries.GetChatMessages
{
    public class GetChatMessagesQuery : IRequest<ChatMessagesVm>
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
    }
}
