using MediatR;

namespace Verbum.Application.Verbum.Message.Queries.GetUnreadMessageCounter
{
    public class GetUnreadMessageCounterQuery : IRequest<int>
    {
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
    }
}
