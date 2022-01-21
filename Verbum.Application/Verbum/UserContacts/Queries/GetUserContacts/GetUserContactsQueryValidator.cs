using FluentValidation;

namespace Verbum.Application.Verbum.UserContacts.Queries.GetUserContacts
{
    public class GetUserContactsQueryValidator :AbstractValidator<GetUserContactsQuery>
    {
        public GetUserContactsQueryValidator() {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
