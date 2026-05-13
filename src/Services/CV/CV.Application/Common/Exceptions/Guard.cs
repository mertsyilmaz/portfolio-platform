namespace CV.Application.Common.Exceptions
{
    public static class Guard
    {
        public static void AgainstNotFound<T>(T? entity, string message) where T : class
        {
            if (entity is null)
                throw new NotFoundException(message);
        }

        public static void AgainstInvalidReference(bool exists, string message)
        {
            if (!exists)
                throw new ValidationException(message);
        }

        public static void AgainstInvalidInput(bool condition, string message)
        {
            if (condition)
                throw new ValidationException(message);
        }

        public static void AgainstBusinessRule(bool condition, string message)
        {
            if (condition)
                throw new BusinessRuleException(message);
        }
    }
}
