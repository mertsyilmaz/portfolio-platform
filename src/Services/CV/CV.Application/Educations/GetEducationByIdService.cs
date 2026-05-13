using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Educations;

namespace CV.Application.Educations
{
    public class GetEducationByIdService : IGetEducationByIdService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public GetEducationByIdService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<GetEducationByIdResponse> GetByIdAsync(Guid id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(education, ErrorMessages.EducationNotFound);
            return _mapper.Map<GetEducationByIdResponse>(education);
        }
    }
}
