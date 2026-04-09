using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public interface IUpdateCertificateService
    {
        Task<UpdateCertificateResponse?> UpdateAsync(Guid id, UpdateCertificateRequest request);
    }
}
