using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Certificates;

namespace CV.Application.Certificates
{
    public class GetCertificatesService : IGetCertificatesService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public GetCertificatesService(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCertificatesResponse>> GetAllAsync()
        {
            var certificates = await _certificateRepository.GetAllAsync();
            return _mapper.Map<List<GetCertificatesResponse>>(certificates);
        }
    }
}
