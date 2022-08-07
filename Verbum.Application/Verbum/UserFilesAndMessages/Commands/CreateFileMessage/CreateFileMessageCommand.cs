using MediatR;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Commands.CreateFileMessage
{
    public class CreateFileMessageCommand :IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
        public Guid Seller { get; set; }
        public Guid UserId { get; set; }
    }
}
