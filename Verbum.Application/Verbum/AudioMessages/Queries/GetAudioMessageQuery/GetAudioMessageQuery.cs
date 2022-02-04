using MediatR;

namespace Verbum.Application.Verbum.AudioMessages.Queries.GetAudioMessageQuery
{
    public class GetAudioMessageQuery :IRequest<AudioMessageVm>
    {
        public Guid MessageId { get; set; }
    }
}
