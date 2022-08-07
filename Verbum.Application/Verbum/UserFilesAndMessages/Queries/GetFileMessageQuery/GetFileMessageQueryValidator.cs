using FluentValidation;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Queries.GetFileMessageQuery
{
    public class GetFileMessageQueryValidator : AbstractValidator<GetFileMessageQuery>
    {
        public GetFileMessageQueryValidator() {
            RuleFor(f => f.MessageId).NotEqual(Guid.Empty);
        }
    }
}
