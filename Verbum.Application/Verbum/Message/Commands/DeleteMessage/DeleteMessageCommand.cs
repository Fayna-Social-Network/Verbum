using MediatR;

namespace Verbum.Application.Verbum.Commands.DeleteMessage
{
    public class DeleteMessageCommand :IRequest
    {
       
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
