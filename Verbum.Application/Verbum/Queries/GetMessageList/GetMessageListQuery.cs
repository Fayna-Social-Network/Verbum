using MediatR;

namespace Verbum.Application.Verbum.Queries.GetMessageList
{
    public class GetMessageListQuery :IRequest<MessageListVm>
    {
        public Guid UserId { get; set; }
    }
}
