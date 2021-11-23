using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsByIdQueryValidator: AbstractValidator<GetAuthorsByIdQuery>
    {
        public GetAuthorsByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty();
        }
    }
}
