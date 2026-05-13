using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Hobbies;

namespace CV.Application.Hobbies
{
    public class UpdateHobbyService : IUpdateHobbyService
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public UpdateHobbyService(IHobbyRepository hobbyRepository, IMapper mapper)
        {
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateHobbyResponse> UpdateAsync(Guid id, UpdateHobbyRequest request)
        {
            var hobby = await _hobbyRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(hobby, ErrorMessages.HobbyNotFound);

            _mapper.Map(request, hobby);
            await _hobbyRepository.UpdateAsync(hobby);

            return _mapper.Map<UpdateHobbyResponse>(hobby);
        }
    }
}
