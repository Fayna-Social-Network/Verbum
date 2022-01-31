using MediatR;

namespace Verbum.Application.Verbum.Message.Commands.SetMessageIsRead
{
    public class SetMessageIsReadCommand :IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
