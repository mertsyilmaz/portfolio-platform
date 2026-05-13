using Blog.Application.Common.Validation;
using Blog.Contracts.Tags;
using FluentValidation;

namespace Blog.Application.Common.Validators.Tags
{
    public class CreateTagRequestValidator : AbstractValidator<CreateTagRequest>
    {
        public CreateTagRequestValidator()
        {
            RuleFor(x => x.Name)
                .MustBeRequiredName("Tag name", 100);
        }
    }
}
