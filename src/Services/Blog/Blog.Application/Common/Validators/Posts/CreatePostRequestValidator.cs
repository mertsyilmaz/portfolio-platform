using Blog.Contracts.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Validators.Posts
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author id is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug is required.")
                .MaximumLength(200).WithMessage("Slug cannot exceed 200 characters.");

            RuleFor(x => x.Summary)
                .NotEmpty().WithMessage("Summary is required.")
                .MaximumLength(500).WithMessage("Summary cannot exceed 500 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Display order cannot be negative.");

            RuleFor(x => x.CategoryIds)
                .NotNull().WithMessage("Category ids are required.");

            RuleFor(x => x.TagIds)
                .NotNull().WithMessage("Tag ids are required.");
        }
    }
}
