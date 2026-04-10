using System;
using System.Collections.Generic;
using System.Text;

namespace File.Contracts.Files
{
    public class DeleteFileResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
