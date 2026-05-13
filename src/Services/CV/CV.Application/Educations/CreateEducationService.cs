using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Educations;
using CV.Domain.Entities;

namespace CV.Application.Educations
{
    public class CreateEducationService : ICreateEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public CreateEducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<CreateEducationResponse> CreateAsync(CreateEducationRequest request)
        {
            var education = _mapper.Map<Education>(request);
            await _educationRepository.AddAsync(education);
            return _mapper.Map<CreateEducationResponse>(education);
        }
    }
}
