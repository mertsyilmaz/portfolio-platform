using File.Domain.Common;

namespace File.Domain.Entities
{
    public class FileRecord : CreatableEntity
    {
        public string FileName { get; set; } = null!;

        public string StoredFileName { get; set; } = null!;

        public string ContentType { get; set; } = null!;

        public string Extension { get; set; } = null!;

        public long Size { get; set; }

        public string RelativePath { get; set; } = null!;

        public string FolderName { get; set; } = null!;
    }
}
