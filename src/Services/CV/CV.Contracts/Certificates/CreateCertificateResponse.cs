namespace CV.Contracts.Certificates
{
    public class CreateCertificateResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Issuer { get; set; } = null!;

    }
}
