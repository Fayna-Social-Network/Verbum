using MediatR;

namespace Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage
{
    public class AddAudioMessageCommand :IRequest<Guid>
    {
        public List<AudioFileModel>? audioFiles { get; set; }
        public Guid SellerId { get; set; }
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
    }
}
