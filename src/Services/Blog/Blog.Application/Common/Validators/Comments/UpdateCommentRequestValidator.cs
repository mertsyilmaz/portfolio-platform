using Blog.Application.Common.Validation;
using Blog.Contracts.Comments;
using FluentValidation;

namespace Blog.Application.Common.Validators.Comments
{
    public class UpdateCommentRequestValidator : AbstractValidator<UpdateCommentRequest>
    {
        public UpdateCommentRequestValidator()
        {
            RuleFor(x => x.Content)
                .MustBeRequiredText("Content", 1000);
        }
    }
}
