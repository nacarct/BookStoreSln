using System;
using System.Data;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(c => c.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.PageCount).GreaterThan(0);
            RuleFor(c => c.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(c => c.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}