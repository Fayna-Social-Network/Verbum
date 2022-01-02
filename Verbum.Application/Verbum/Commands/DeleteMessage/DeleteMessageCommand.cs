using MediatR;

namespace Verbum.Application.Verbum.Commands.DeleteMessage
{
    public class DeleteMessageCommand :IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
