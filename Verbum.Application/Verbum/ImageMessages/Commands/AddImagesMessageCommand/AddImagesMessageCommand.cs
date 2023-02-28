using MediatR;

namespace Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand
{
    public class AddImagesMessageCommand :IRequest<Guid>
    {
        public Guid SellerId { get; set; }
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string[]? ImagePaths { get; set; }
    }
}
