﻿using FluentValidation;

namespace Verbum.Application.Verbum.Commands.DeleteMessage
{
    public class DeleteMessageCommandValidator :AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageCommandValidator() {
            RuleFor(deleteMessageCommand =>
                deleteMessageCommand.Id).NotEqual(Guid.Empty);
            RuleFor(d => d.UserId).NotEqual(Guid.Empty);
           
        }
    }
}
