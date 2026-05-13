namespace Portfolio.Contracts.Images
{
    public class CreateImageResponse
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsCover { get; set; }
        public Guid ProjectId { get; set; }
    }
}
