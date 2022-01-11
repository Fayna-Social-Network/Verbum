using FluentValidation;

namespace Verbum.Application.Verbum.Message.Queries.GetCorrespondenceWithUnknowContact
{
    public class GetCorrespondenceWithUnknowContactValidator :AbstractValidator<GetCorrespondenceWithUnknowContactQuery>
    {
        public GetCorrespondenceWithUnknowContactValidator() {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
