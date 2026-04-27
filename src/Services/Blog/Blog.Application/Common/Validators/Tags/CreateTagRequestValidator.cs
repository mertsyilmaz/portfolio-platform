using Blog.Contracts.Tags;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Validators.Tags
{
    public class CreateTagRequestValidator : AbstractValidator<CreateTagRequest>
    {
        public CreateTagRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is required.")
                .MaximumLength(100).WithMessage("Tag name cannot exceed 100 characters.");
        }
    }
}
