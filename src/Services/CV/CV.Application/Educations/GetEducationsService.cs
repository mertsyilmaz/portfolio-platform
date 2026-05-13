using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Educations;

namespace CV.Application.Educations
{
    public class GetEducationsService : IGetEducationsService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public GetEducationsService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<List<GetEducationsResponse>> GetAllAsync()
        {
            var educations = await _educationRepository.GetAllAsync();
            return _mapper.Map<List<GetEducationsResponse>>(educations);
        }
    }
}
