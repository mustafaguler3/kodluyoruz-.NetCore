using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Webapi.Entities;

namespace Webapi.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<Genre>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(i=>i.Name).NotEmpty();
        }
    }
}