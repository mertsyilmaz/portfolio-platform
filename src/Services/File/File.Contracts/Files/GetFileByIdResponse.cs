namespace File.Contracts.Files
{
    public class GetFileByIdResponse
    {
        public Guid Id { get; set; }

        public string FileName { get; set; } = null!;

        public string StoredFileName { get; set; } = null!;

        public string ContentType { get; set; } = null!;

        public string Extension { get; set; } = null!;

        public long Size { get; set; }

        public string RelativePath { get; set; } = null!;
        public string FolderName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
