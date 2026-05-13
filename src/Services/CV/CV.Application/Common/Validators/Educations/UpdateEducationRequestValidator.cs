using CV.Application.Common.Validation;
using CV.Contracts.Educations;
using FluentValidation;

namespace CV.Application.Common.Validators.Educations
{
    public class UpdateEducationRequestValidator : AbstractValidator<UpdateEducationRequest>
    {
        public UpdateEducationRequestValidator()
        {
            RuleFor(x => x.SchoolName).MustBeRequiredText("School name", 200);
            RuleFor(x => x.Department).MustBeRequiredText("Department", 150);
            RuleFor(x => x.Degree).MustBeRequiredText("Degree", 100);
            RuleFor(x => x.Description).MustBeRequiredContent("Description", 2000);
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("End date must be greater than or equal to start date.");
        }
    }
}
