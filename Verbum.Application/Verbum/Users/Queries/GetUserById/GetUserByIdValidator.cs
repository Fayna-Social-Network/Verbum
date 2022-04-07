using FluentValidation;

namespace Verbum.Application.Verbum.Users.Queries.GetUserById
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator() {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
