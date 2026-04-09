using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public interface IGetCertificateByIdService
    {
        Task<GetCertificateByIdResponse?> GetByIdAsync(Guid id);
    }
}
