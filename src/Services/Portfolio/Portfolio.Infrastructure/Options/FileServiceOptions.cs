using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Infrastructure.Options
{
    public class FileServiceOptions
    {
        public const string SectionName = "Services:File";

        [Required]
        public string BaseUrl { get; set; } = string.Empty;

        [Range(1, 300)]
        public int TimeoutSeconds { get; set; } = 30;
    }
}
