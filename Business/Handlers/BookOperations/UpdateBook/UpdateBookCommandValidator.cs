using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model).NotNull();
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);

        }
    }
}
