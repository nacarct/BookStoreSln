using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.PageCount).GreaterThan(0);
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(c => c.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}