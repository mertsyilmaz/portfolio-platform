using CV.Application.Common.Validation;
using CV.Contracts.Hobbies;
using FluentValidation;

namespace CV.Application.Common.Validators.Hobbies
{
    public class CreateHobbyRequestValidator : AbstractValidator<CreateHobbyRequest>
    {
        public CreateHobbyRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredText("Name", 150);
            RuleFor(x => x.Description).MustBeRequiredContent("Description", 2000);
        }
    }
}
