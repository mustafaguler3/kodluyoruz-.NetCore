using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.BookOperations.UpdateBook
{
    public class UpdateBookQueryValidator : AbstractValidator<Book>
    {
        public UpdateBookQueryValidator()
        {
            RuleFor(i => i.PageCount).NotEmpty();
            RuleFor(i => i.Title).NotEmpty();
            RuleFor(i => i.PublishDate).NotEmpty();
        }
    }
}
