using Blog.Application.Common.Validation;
using Blog.Contracts.Images;
using FluentValidation;

namespace Blog.Application.Common.Validators.Images
{
    public class UpdateImageRequestValidator : AbstractValidator<UpdateImageRequest>
    {
        public UpdateImageRequestValidator()
        {
            RuleFor(x => x.FileId)
                .MustBeRequiredId("File id");

            RuleFor(x => x.DisplayOrder)
                .MustBeNonNegative("Display order");
        }
    }
}
