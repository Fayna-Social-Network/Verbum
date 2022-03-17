using MediatR;

namespace Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage
{
    public class AddAudioMessageCommand :IRequest<Guid>
    {
        public string? Path { get; set; }
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
    }
}
