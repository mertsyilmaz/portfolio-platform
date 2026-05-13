using FluentValidation;
using Portfolio.Application.Common.Validation;
using Portfolio.Contracts.Images;

namespace Portfolio.Application.Common.Validators.Images
{
    public class CreateImageRequestValidator : AbstractValidator<CreateImageRequest>
    {
        public CreateImageRequestValidator()
        {
            RuleFor(x => x.FileId).MustBeRequiredId("File id");
            RuleFor(x => x.ProjectId).MustBeRequiredId("Project id");
            RuleFor(x => x.DisplayOrder).MustBeNonNegative("Display order");
        }
    }
}
