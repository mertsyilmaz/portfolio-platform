using FluentValidation;
using Portfolio.Application.Common.Validation;
using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Common.Validators.Architectures
{
    public class CreateArchitectureRequestValidator : AbstractValidator<CreateArchitectureRequest>
    {
        public CreateArchitectureRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredName("Architecture name", 100);
        }
    }
}
