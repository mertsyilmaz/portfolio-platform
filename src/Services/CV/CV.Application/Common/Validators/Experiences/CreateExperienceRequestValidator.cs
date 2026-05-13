using CV.Application.Common.Validation;
using CV.Contracts.Experiences;
using FluentValidation;

namespace CV.Application.Common.Validators.Experiences
{
    public class CreateExperienceRequestValidator : AbstractValidator<CreateExperienceRequest>
    {
        public CreateExperienceRequestValidator()
        {
            RuleFor(x => x.CompanyName).MustBeRequiredText("Company name", 200);
            RuleFor(x => x.Position).MustBeRequiredText("Position", 150);
            RuleFor(x => x.Description).MustBeRequiredContent("Description", 2000);
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("End date must be greater than or equal to start date.");
        }
    }
}
