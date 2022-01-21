using MediatR;
using Verbum.Application.Verbum.Message.Queries.GetCorrespondence;

namespace Verbum.Application.Verbum.Message.Queries.GetCorrespondenceWithUnknowContact
{
    public class GetCorrespondenceWithUnknowContactQuery :IRequest<CorrespondenceVm>
    {
        public Guid UserId { get; set; }
    }
}
