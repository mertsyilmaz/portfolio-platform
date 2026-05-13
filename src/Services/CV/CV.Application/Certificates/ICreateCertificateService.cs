using CV.Contracts.Certificates;

namespace CV.Application.Certificates
{
    public interface ICreateCertificateService
    {
        Task<CreateCertificateResponse> CreateAsync(CreateCertificateRequest request);
    }
}
