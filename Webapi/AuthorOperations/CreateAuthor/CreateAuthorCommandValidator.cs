using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Webapi.Entities;

namespace Webapi.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<Author>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(i=>i.Name).NotEmpty();
            RuleFor(i=>i.Lastname).NotEmpty();
            RuleFor(i=>i.BirthDay).NotEmpty();
        }
    }
}