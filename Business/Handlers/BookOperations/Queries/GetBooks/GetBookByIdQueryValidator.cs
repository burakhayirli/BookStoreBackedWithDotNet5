using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.BookOperations.GetBooks
{
    public class GetBookByIdQueryValidator: AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
