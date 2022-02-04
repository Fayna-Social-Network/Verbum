using MediatR;

namespace Verbum.Application.Verbum.Reactions.Queries.GetReactionsQuery
{
    public class GetReactionsQuery :IRequest<ReactionsVm>
    {
        public Guid MessageId { get; set; }
    }
}
