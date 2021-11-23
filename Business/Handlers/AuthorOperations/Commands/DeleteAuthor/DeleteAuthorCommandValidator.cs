using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.AuthorOperations.Commands.DeleteAuthor
{
   public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0).NotEmpty();
            
        }
    }
}
