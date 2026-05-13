using Blog.Application.Common.Validation;
using Blog.Contracts.Categories;
using FluentValidation;

namespace Blog.Application.Common.Validators.Categories
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .MustBeRequiredName("Category name", 100);
        }
    }
}
