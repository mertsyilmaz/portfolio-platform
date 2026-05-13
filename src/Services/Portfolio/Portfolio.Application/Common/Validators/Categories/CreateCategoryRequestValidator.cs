using FluentValidation;
using Portfolio.Application.Common.Validation;
using Portfolio.Contracts.Categories;

namespace Portfolio.Application.Common.Validators.Categories
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredName("Category name", 100);
        }
    }
}
