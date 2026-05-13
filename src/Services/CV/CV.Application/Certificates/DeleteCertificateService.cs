using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;

namespace CV.Application.Certificates
{
    public class DeleteCertificateService : IDeleteCertificateService
    {
        private readonly ICertificateRepository _certificateRepository;

        public DeleteCertificateService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(certificate, ErrorMessages.CertificateNotFound);
            await _certificateRepository.DeleteAsync(certificate);
        }
    }
}
