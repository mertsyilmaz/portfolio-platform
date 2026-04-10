using System;
using System.Collections.Generic;
using System.Text;

namespace File.Contracts.Files
{
    public class GetFilesResponse
    {
        public Guid Id { get; set; }

        public string FileName { get; set; } = null!;

        public string ContentType { get; set; } = null!;

        public long Size { get; set; }

        public string RelativePath { get; set; } = null!;
    }
}
