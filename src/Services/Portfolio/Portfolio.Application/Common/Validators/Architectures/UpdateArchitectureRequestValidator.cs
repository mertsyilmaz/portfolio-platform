using FluentValidation;
using Portfolio.Application.Common.Validation;
using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Common.Validators.Architectures
{
    public class UpdateArchitectureRequestValidator : AbstractValidator<UpdateArchitectureRequest>
    {
        public UpdateArchitectureRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredName("Architecture name", 100);
        }
    }
}
