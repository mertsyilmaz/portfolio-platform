using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Certificates;

namespace CV.Application.Certificates
{
    public class GetCertificateByIdService : IGetCertificateByIdService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public GetCertificateByIdService(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<GetCertificateByIdResponse> GetByIdAsync(Guid id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(certificate, ErrorMessages.CertificateNotFound);
            return _mapper.Map<GetCertificateByIdResponse>(certificate);
        }
    }
}
