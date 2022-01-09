using FluentValidation;

namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class GetCurrentUserValidator :AbstractValidator<GetCurrentUserQuery>
    {
        public GetCurrentUserValidator() {
            RuleFor(x => x.NickName).NotNull();
        }
    }
}
