using MediatR;
using Verbum.Application.UserGrops.UserGroup.Queries.GetAllGroups;

namespace Verbum.Application.UserGrops.UserGroup.Queries.GetUserGroups
{
    public class GetUserGroupsQuery :IRequest<GetAllGroupsVm>
    {
        public Guid UserId { get; set; }
    }
}
