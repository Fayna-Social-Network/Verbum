using FluentValidation;

namespace Verbum.Application.Verbum.Queries.GetMessageList
{
    public class GetMessageListQueryValidator :AbstractValidator<GetMessageListQuery>
    {
        public GetMessageListQueryValidator() {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
