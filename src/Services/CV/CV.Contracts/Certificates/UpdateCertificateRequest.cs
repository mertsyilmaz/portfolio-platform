namespace CV.Contracts.Certificates
{
    public class UpdateCertificateRequest
    {

        public string Name { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public DateTime IssuedDate { get; set; }

        public string? CredentialId { get; set; }

        public string? CredentialUrl { get; set; }

    }
}
