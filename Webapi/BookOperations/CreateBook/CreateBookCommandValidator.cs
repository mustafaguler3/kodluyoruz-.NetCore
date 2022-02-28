using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty();
            RuleFor(i=>i.Model.PageCount).GreaterThan(0);
            RuleFor(i => i.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(i => i.Model.GenreId).GreaterThan(0);
        }
    }
}
