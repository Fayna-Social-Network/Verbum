﻿using FluentValidation;
using MediatR;

namespace Verbum.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        :IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(failture => failture != null)
                    .ToList();

            if (failtures.Count != 0) {
                throw new ValidationException(failtures);
            }

            return next();
        }
    }
}
