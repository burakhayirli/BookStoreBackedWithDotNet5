using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
