using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator: AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}
