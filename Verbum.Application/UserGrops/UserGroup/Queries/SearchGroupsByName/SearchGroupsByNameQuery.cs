using MediatR;
using Verbum.Application.UserGrops.UserGroup.Queries.GetAllGroups;

namespace Verbum.Application.UserGrops.UserGroup.Queries.SearchGroupsByName
{
    public class SearchGroupsByNameQuery :IRequest<GetAllGroupsVm>
    {
        public string? GroupName { get; set; }
    }
}
