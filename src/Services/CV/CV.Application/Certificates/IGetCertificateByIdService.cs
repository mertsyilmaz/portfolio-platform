using CV.Contracts.Certificates;

namespace CV.Application.Certificates
{
    public interface IGetCertificateByIdService
    {
        Task<GetCertificateByIdResponse> GetByIdAsync(Guid id);
    }
}
