using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
