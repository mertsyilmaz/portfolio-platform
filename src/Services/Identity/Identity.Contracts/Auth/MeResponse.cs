namespace Identity.Contracts.Auth
{
    public class MeResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = null!;
        public string[] Roles { get; set; } = [];
    }
}
