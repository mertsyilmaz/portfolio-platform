using FluentValidation;

namespace CV.Application.Common.Validation
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeRequiredText<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            string fieldName,
            int maxLength)
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"{fieldName} is required.")
                .MaximumLength(maxLength).WithMessage($"{fieldName} cannot exceed {maxLength} characters.");
        }

        public static IRuleBuilderOptions<T, string> MustBeRequiredContent<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            string fieldName,
            int maxLength)
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"{fieldName} is required.")
                .MaximumLength(maxLength).WithMessage($"{fieldName} cannot exceed {maxLength} characters.");
        }

        public static IRuleBuilderOptions<T, int> MustBeNonNegative<T>(
            this IRuleBuilder<T, int> ruleBuilder,
            string fieldName)
        {
            return ruleBuilder
                .GreaterThanOrEqualTo(0).WithMessage($"{fieldName} cannot be negative.");
        }
    }
}
