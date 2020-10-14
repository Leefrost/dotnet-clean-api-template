using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace CleanApiTemplate.Application.Common
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any()) 
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var result = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failed = result.SelectMany(task => task.Errors).Where(message => message != null).ToList();

            if (failed.Count != 0)
            {
                throw new ServerSideValidationException(failed);
            }

            return await next();
        }
    }
}
