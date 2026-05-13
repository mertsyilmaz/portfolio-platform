using Blog.Application.Common.Validation;
using Blog.Contracts.Posts;
using FluentValidation;

namespace Blog.Application.Common.Validators.Posts
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.AuthorId)
                .MustBeRequiredId("Author id");

            RuleFor(x => x.Title)
                .MustBeRequiredText("Title", 200);

            RuleFor(x => x.Slug)
                .MustBeRequiredText("Slug", 200);

            RuleFor(x => x.Summary)
                .MustBeRequiredText("Summary", 500);

            RuleFor(x => x.Content)
                .MustBeRequiredContent("Content");

            RuleFor(x => x.DisplayOrder)
                .MustBeNonNegative("Display order");

            RuleFor(x => x.CategoryIds)
                .MustBeRequiredCollection("Category ids");

            RuleFor(x => x.TagIds)
                .MustBeRequiredCollection("Tag ids");
        }
    }
}
