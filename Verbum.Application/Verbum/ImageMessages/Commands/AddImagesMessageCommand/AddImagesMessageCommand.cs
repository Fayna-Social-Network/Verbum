using MediatR;

namespace Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand
{
    public class AddImagesMessageCommand :IRequest<Guid>
    {
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }
        public string[]? DbImagePath { get; set; }
    }
}
