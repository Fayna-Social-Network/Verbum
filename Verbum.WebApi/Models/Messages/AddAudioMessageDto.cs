using Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage;

namespace Verbum.WebApi.Models.Messages
{
    public class AddAudioMessageDto 
    {
        public List<AudioFileModel>? audioFiles { get; set; }
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
    }
}
