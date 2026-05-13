using CV.Application.Common.Validation;
using CV.Contracts.Languages;
using FluentValidation;

namespace CV.Application.Common.Validators.Languages
{
    public class UpdateLanguageRequestValidator : AbstractValidator<UpdateLanguageRequest>
    {
        public UpdateLanguageRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredText("Name", 100);
            RuleFor(x => x.Level).MustBeRequiredText("Level", 100);
        }
    }
}
