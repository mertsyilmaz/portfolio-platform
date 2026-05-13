namespace CV.Contracts.SocialLinks
{
    public class CreateSocialLinkResponse
    {
        public Guid Id { get; set; }

        public string Platform { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
