namespace Portfolio.Contracts.Images
{
    public class CreateImageRequest
    {
        public Guid FileId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsCover { get; set; }
        public Guid ProjectId { get; set; }
    }
}
