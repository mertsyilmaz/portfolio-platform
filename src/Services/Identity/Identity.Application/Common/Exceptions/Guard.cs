namespace Identity.Application.Common.Exceptions
{
    public static class Guard
    {
        public static void AgainstUnauthorized(bool isAuthorized, string message)
        {
            if (!isAuthorized)
            {
                throw new UnauthorizedException(message);
            }
        }
    }
}
