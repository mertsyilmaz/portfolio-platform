using CV.Contracts.Certificates;

namespace CV.Application.Certificates
{
    public interface IUpdateCertificateService
    {
        Task<UpdateCertificateResponse> UpdateAsync(Guid id, UpdateCertificateRequest request);
    }
}
