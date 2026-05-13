using FluentValidation;
using Portfolio.Application.Common.Validation;
using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Common.Validators.Technologies
{
    public class UpdateTechnologyRequestValidator : AbstractValidator<UpdateTechnologyRequest>
    {
        public UpdateTechnologyRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredName("Technology name", 100);
        }
    }
}
