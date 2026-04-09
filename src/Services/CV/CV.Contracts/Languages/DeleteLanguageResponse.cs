using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Languages
{
    public class DeleteLanguageResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}
