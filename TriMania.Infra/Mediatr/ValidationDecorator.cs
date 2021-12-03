using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR.Pipeline;
using Trimania.Shared.Exceptions;

namespace TriMania.Infra.Mediatr
{
    public class ValidationDecorator<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationDecorator(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                var result = await _validator.ValidateAsync(request, cancellationToken);

                if (result.Errors.Any()) throw new BusinessRuleException(result.Errors.First().ErrorMessage);
            }
        }
    }
}