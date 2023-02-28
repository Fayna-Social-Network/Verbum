using MediatR;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Commands.CreateFileMessage
{
    public class CreateFileMessageCommand :IRequest<Guid>
    {
        public string? Text { get; set; }
        public string[]? Paths { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public Guid Seller { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
