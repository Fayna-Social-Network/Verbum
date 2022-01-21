using MediatR;

namespace Verbum.Application.Verbum.Message.Queries.GetCorrespondence
{
    public class GetCorrespondenceQuery :IRequest<CorrespondenceVm>
    {
        public Guid Owner { get; set; }
        public Guid WithWho { get; set; }
    }
}
