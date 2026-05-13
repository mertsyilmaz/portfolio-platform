namespace CV.Contracts.SocialLinks
{
    public class UpdateSocialLinkResponse
    {
        public Guid Id { get; set; }

        public string Platform { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
