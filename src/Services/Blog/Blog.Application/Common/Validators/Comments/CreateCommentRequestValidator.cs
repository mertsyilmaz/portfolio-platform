using Blog.Application.Common.Validation;
using Blog.Contracts.Comments;
using FluentValidation;

namespace Blog.Application.Common.Validators.Comments
{
    public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentRequestValidator()
        {
            RuleFor(x => x.PostId)
                .MustBeRequiredId("Post id");

            RuleFor(x => x.AuthorId)
                .MustBeRequiredId("Author id");

            RuleFor(x => x.Content)
                .MustBeRequiredText("Content", 1000);
        }
    }
}
