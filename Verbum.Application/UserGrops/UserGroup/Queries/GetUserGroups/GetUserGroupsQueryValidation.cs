using FluentValidation;

namespace Verbum.Application.UserGrops.UserGroup.Queries.GetUserGroups
{
    public class GetUserGroupsQueryValidation : AbstractValidator<GetUserGroupsQuery>
    {
        public GetUserGroupsQueryValidation() {
            RuleFor(g => g.UserId).NotEqual(Guid.Empty);
        }
    }
}
