using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
    {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
    }
}
}
