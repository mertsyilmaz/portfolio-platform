using Blog.Contracts.Images;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Validators.Images
{
    public class CreateImageRequestValidator : AbstractValidator<CreateImageRequest>
    {
        public CreateImageRequestValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("Post id is required.");

            RuleFor(x => x.FileId)
                .NotEmpty().WithMessage("File id is required.");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Display order cannot be negative.");
        }
    }
}
