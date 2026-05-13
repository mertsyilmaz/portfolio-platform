using Blog.Application.Common.Validation;
using Blog.Contracts.Images;
using FluentValidation;

namespace Blog.Application.Common.Validators.Images
{
    public class CreateImageRequestValidator : AbstractValidator<CreateImageRequest>
    {
        public CreateImageRequestValidator()
        {
            RuleFor(x => x.PostId)
                .MustBeRequiredId("Post id");

            RuleFor(x => x.FileId)
                .MustBeRequiredId("File id");

            RuleFor(x => x.DisplayOrder)
                .MustBeNonNegative("Display order");
        }
    }
}
