using CV.Application.Common.Validation;
using CV.Contracts.SocialLinks;
using FluentValidation;

namespace CV.Application.Common.Validators.SocialLinks
{
    public class UpdateSocialLinkRequestValidator : AbstractValidator<UpdateSocialLinkRequest>
    {
        public UpdateSocialLinkRequestValidator()
        {
            RuleFor(x => x.Platform).MustBeRequiredText("Platform", 100);
            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Url is required.")
                .MaximumLength(500).WithMessage("Url cannot exceed 500 characters.")
                .Must(x => Uri.IsWellFormedUriString(x, UriKind.Absolute))
                .WithMessage("Url must be a valid absolute URL.");
            RuleFor(x => x.DisplayOrder).MustBeNonNegative("Display order");
        }
    }
}
