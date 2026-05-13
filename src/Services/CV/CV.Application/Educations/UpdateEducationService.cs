using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Educations;

namespace CV.Application.Educations
{
    public class UpdateEducationService : IUpdateEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public UpdateEducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<UpdateEducationResponse> UpdateAsync(Guid id, UpdateEducationRequest request)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(education, ErrorMessages.EducationNotFound);

            _mapper.Map(request, education);
            await _educationRepository.UpdateAsync(education);

            return _mapper.Map<UpdateEducationResponse>(education);
        }
    }
}
