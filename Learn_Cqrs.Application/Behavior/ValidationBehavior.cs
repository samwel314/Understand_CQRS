
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learn_Cqrs.Application.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
       
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();    
            var context = new ValidationContext<TRequest>(request);     
            var result = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));  
            var failures = result.SelectMany(r => r.Errors).Where(f => f != null).ToList(); 
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return await next();
        }
    }
}

