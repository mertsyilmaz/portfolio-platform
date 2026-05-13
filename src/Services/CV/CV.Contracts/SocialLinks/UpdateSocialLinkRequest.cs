namespace CV.Contracts.SocialLinks
{
    public class UpdateSocialLinkRequest
    {
        public string Platform { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
