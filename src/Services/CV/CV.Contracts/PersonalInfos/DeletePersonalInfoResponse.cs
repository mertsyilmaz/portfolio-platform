using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.PersonalInfos
{
    public class DeletePersonalInfoResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
