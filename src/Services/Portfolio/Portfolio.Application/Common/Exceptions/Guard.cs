namespace Portfolio.Application.Common.Exceptions
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

        public static void AgainstInvalidIds(int expectedCount, int actualCount, string message)
        {
            if (expectedCount != actualCount)
                throw new ValidationException(message);
        }
    }
}
