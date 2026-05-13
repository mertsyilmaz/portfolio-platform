using FluentValidation;

namespace Portfolio.Application.Common.Validation
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeRequiredName<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            string fieldName,
            int maxLength)
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"{fieldName} is required.")
                .MaximumLength(maxLength).WithMessage($"{fieldName} cannot exceed {maxLength} characters.");
        }

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
            string fieldName)
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"{fieldName} is required.");
        }

        public static IRuleBuilderOptions<T, Guid> MustBeRequiredId<T>(
            this IRuleBuilder<T, Guid> ruleBuilder,
            string fieldName)
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"{fieldName} is required.");
        }

        public static IRuleBuilderOptions<T, int> MustBeNonNegative<T>(
            this IRuleBuilder<T, int> ruleBuilder,
            string fieldName)
        {
            return ruleBuilder
                .GreaterThanOrEqualTo(0).WithMessage($"{fieldName} cannot be negative.");
        }

        public static IRuleBuilderOptions<T, IEnumerable<Guid>> MustBeRequiredCollection<T>(
            this IRuleBuilder<T, IEnumerable<Guid>> ruleBuilder,
            string fieldName)
        {
            return ruleBuilder
                .NotNull().WithMessage($"{fieldName} are required.");
        }
    }
}
