using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Certificates;

namespace CV.Application.Certificates
{
    public class UpdateCertificateService : IUpdateCertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public UpdateCertificateService(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCertificateResponse> UpdateAsync(Guid id, UpdateCertificateRequest request)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(certificate, ErrorMessages.CertificateNotFound);

            _mapper.Map(request, certificate);
            await _certificateRepository.UpdateAsync(certificate);

            return _mapper.Map<UpdateCertificateResponse>(certificate);
        }
    }
}
