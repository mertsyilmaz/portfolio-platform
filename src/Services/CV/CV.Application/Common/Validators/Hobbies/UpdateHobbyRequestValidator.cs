using CV.Application.Common.Validation;
using CV.Contracts.Hobbies;
using FluentValidation;

namespace CV.Application.Common.Validators.Hobbies
{
    public class UpdateHobbyRequestValidator : AbstractValidator<UpdateHobbyRequest>
    {
        public UpdateHobbyRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredText("Name", 150);
            RuleFor(x => x.Description).MustBeRequiredContent("Description", 2000);
        }
    }
}
