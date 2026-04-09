using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public interface ICreateCertificateService
    {
        Task<CreateCertificateResponse> CreateAsync(CreateCertificateRequest request);
    }
}
