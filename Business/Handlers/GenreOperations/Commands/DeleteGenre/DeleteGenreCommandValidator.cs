using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator: AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}
