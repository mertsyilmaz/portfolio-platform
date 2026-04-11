using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Projects
{
    public class DeleteProjectResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
