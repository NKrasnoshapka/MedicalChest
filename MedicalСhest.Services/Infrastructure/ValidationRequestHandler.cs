using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Library.Services.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public sealed class ValidationRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;
        private readonly IRequestHandler<TRequest, TResponse> _inner;

        public ValidationRequestHandler(IValidator<TRequest> validator, IRequestHandler<TRequest, TResponse> inner)
        {
            _validator = validator;
            _inner = inner;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator
                .ValidateAsync(request, cancellationToken)
                .ConfigureAwait(false);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Validation exception", validationResult.Errors);
            }

            return await _inner.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
