using FluentValidation;

namespace Verbum.Application.Verbum.BlockedUsers.Queries.IsUserBlockedMe
{
    public class IsUserBlockedMeQueryValidator :AbstractValidator<IsUserBlockedMeQuery>
    {
        public IsUserBlockedMeQueryValidator() {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.CheckUserId).NotEqual(Guid.Empty);
        }
    }
}
