using Blog.Application.Common.Validation;
using Blog.Contracts.Tags;
using FluentValidation;

namespace Blog.Application.Common.Validators.Tags
{
    public class UpdateTagRequestValidator : AbstractValidator<UpdateTagRequest>
    {
        public UpdateTagRequestValidator()
        {
            RuleFor(x => x.Name)
                .MustBeRequiredName("Tag name", 100);
        }
    }
}
