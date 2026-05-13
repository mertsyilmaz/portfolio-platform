using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Certificates;
using CV.Domain.Entities;

namespace CV.Application.Certificates
{
    public class CreateCertificateService : ICreateCertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public CreateCertificateService(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<CreateCertificateResponse> CreateAsync(CreateCertificateRequest request)
        {
            var certificate = _mapper.Map<Certificate>(request);
            await _certificateRepository.AddAsync(certificate);
            return _mapper.Map<CreateCertificateResponse>(certificate);
        }
    }
}
