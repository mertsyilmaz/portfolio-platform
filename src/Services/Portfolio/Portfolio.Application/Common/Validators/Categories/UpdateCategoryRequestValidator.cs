using FluentValidation;
using Portfolio.Application.Common.Validation;
using Portfolio.Contracts.Categories;

namespace Portfolio.Application.Common.Validators.Categories
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredName("Category name", 100);
        }
    }
}
