using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(q => q.BookId).GreaterThan(0);
        }
    }
}