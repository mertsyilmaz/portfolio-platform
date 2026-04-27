using Blog.Contracts.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Validators.Categories
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters.");
        }
    }
}
