using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Hobbies
{
    public class DeleteHobbyResponse
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
