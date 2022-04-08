using MediatR;

namespace Verbum.Application.Verbum.VideoMessages.Queries
{
    public class GetVideoMessageQuery :IRequest<videoMessageVm>
    {
        public Guid MessageId { get; set; } 
    }
}
