using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public interface IGetCertificatesService
    {
        Task<List<GetCertificatesResponse>> GetAllAsync();
    }
}
