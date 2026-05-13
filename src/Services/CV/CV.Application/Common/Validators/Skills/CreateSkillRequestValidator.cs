using CV.Application.Common.Validation;
using CV.Contracts.Skills;
using FluentValidation;

namespace CV.Application.Common.Validators.Skills
{
    public class CreateSkillRequestValidator : AbstractValidator<CreateSkillRequest>
    {
        public CreateSkillRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredText("Name", 150);
            RuleFor(x => x.Level).MustBeRequiredText("Level", 100);
            RuleFor(x => x.Category).MustBeRequiredText("Category", 100);
        }
    }
}
