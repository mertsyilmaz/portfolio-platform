using System;
using System.Collections.Generic;
using System.Text;

namespace File.Domain.Entities
{
    public class FileRecord
    {
        public Guid Id { get; set; }

        public string FileName { get; set; } = null!;

        public string StoredFileName { get; set; } = null!;

        public string ContentType { get; set; } = null!;

        public string Extension { get; set; } = null!;

        public long Size { get; set; }

        public string RelativePath { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
