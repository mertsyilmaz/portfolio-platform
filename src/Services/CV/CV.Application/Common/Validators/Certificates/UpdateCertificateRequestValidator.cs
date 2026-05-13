using CV.Application.Common.Validation;
using CV.Contracts.Certificates;
using FluentValidation;

namespace CV.Application.Common.Validators.Certificates
{
    public class UpdateCertificateRequestValidator : AbstractValidator<UpdateCertificateRequest>
    {
        public UpdateCertificateRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredText("Name", 200);
            RuleFor(x => x.Issuer).MustBeRequiredText("Issuer", 200);
            RuleFor(x => x.CredentialId)
                .MaximumLength(200)
                .When(x => !string.IsNullOrWhiteSpace(x.CredentialId));
            RuleFor(x => x.CredentialUrl)
                .MaximumLength(500)
                .Must(x => string.IsNullOrWhiteSpace(x) || Uri.IsWellFormedUriString(x, UriKind.Absolute))
                .WithMessage("Credential url must be a valid absolute URL.");
        }
    }
}
