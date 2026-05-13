using Blog.Contracts.Enums;

namespace Blog.Contracts.Images
{
    public class CreateImageRequest
    {
        public Guid PostId { get; set; }
        public Guid FileId { get; set; }
        public ImageUsageType UsageType { get; set; }
        public int DisplayOrder { get; set; }
    }

}
