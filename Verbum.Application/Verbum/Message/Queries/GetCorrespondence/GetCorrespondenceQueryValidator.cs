using FluentValidation;

namespace Verbum.Application.Verbum.Message.Queries.GetCorrespondence
{
    public class GetCorrespondenceQueryValidator :AbstractValidator<GetCorrespondenceQuery>
    {
        public GetCorrespondenceQueryValidator() {
            RuleFor(x => x.Owner).NotEqual(Guid.Empty);
            RuleFor(x => x.WithWho).NotEqual(Guid.Empty);
        }
    }
}
