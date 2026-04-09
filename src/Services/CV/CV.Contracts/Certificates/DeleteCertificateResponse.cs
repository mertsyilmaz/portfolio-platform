using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.Certificates
{
    public class DeleteCertificateResponse
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
