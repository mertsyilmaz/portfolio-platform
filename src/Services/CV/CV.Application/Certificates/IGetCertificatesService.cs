using CV.Contracts.Certificates;

namespace CV.Application.Certificates
{
    public interface IGetCertificatesService
    {
        Task<List<GetCertificatesResponse>> GetAllAsync();
    }
}
