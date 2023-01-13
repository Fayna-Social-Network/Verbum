using MediatR;

namespace Verbum.Application.UserGrops.UserGroup.Queries.GetGroupById
{
    public class GetGroupByIdQuery :IRequest<GetGroupByIdVm>
    {
        public Guid GroupId { get; set; }
    }
}
