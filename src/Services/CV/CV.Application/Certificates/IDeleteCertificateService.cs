using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public interface IDeleteCertificateService
    {
        Task<DeleteCertificateResponse?> DeleteAsync(Guid id);
    }
}
