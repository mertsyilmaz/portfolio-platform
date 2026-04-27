using Blog.Contracts.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Validators.Comments
{
    public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentRequestValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("Post id is required.");

            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author id is required.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters.");
        }
    }
}
