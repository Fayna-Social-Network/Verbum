using MediatR;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Message.Queries.GetMessageById
{
    public class GetMessageByIdQuery :IRequest<Messages>
    {
        public Guid MessageId { get; set; }
    }
}
