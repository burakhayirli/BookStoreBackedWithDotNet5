using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator: AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim()!=string.Empty);
        }
    }
}
