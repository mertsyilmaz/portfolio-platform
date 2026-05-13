namespace CV.Contracts.SocialLinks
{
    public class CreateSocialLinkRequest
    {
        public string Platform { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
