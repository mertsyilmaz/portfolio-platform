using CV.Domain.Common;

namespace CV.Domain.Entities
{
    public class Certificate : CreatableEntity
    {
        public string Name { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public DateTime IssuedDate { get; set; }

        public string? CredentialId { get; set; }

        public string? CredentialUrl { get; set; }
    }
}
