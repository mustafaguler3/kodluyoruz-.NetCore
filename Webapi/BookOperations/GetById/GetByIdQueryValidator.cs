using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.BookOperations.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<Book>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(i => i.PageCount).NotEmpty();
            RuleFor(i => i.Title).NotEmpty();
            RuleFor(i => i.PublishDate).NotEmpty();
        }
    }
}
