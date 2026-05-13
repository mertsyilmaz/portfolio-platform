using Blog.Application.Common.Validation;
using Blog.Contracts.Categories;
using FluentValidation;

namespace Blog.Application.Common.Validators.Categories
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .MustBeRequiredName("Category name", 100);
        }
    }
}
