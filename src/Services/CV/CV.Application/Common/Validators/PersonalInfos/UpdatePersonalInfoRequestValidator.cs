using CV.Application.Common.Validation;
using CV.Contracts.PersonalInfos;
using FluentValidation;

namespace CV.Application.Common.Validators.PersonalInfos
{
    public class UpdatePersonalInfoRequestValidator : AbstractValidator<UpdatePersonalInfoRequest>
    {
        public UpdatePersonalInfoRequestValidator()
        {
            RuleFor(x => x.FirstName).MustBeRequiredText("First name", 100);
            RuleFor(x => x.LastName).MustBeRequiredText("Last name", 100);
            RuleFor(x => x.Title).MustBeRequiredText("Title", 150);
            RuleFor(x => x.Summary).MustBeRequiredContent("Summary", 4000);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Email must be valid.").MaximumLength(200);
            RuleFor(x => x.Phone).MustBeRequiredText("Phone", 50);
            RuleFor(x => x.Location).MustBeRequiredText("Location", 200);
        }
    }
}
