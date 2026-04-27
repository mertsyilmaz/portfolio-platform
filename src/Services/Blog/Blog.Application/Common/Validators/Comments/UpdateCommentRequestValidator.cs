using Blog.Contracts.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Validators.Comments
{
    public class UpdateCommentRequestValidator : AbstractValidator<UpdateCommentRequest>
    {
        public UpdateCommentRequestValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters.");
        }
    }
}
