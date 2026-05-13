using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Hobbies;

namespace CV.Application.Hobbies
{
    public class GetHobbyByIdService : IGetHobbyByIdService
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public GetHobbyByIdService(IHobbyRepository hobbyRepository, IMapper mapper)
        {
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
        }

        public async Task<GetHobbyByIdResponse> GetByIdAsync(Guid id)
        {
            var hobby = await _hobbyRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(hobby, ErrorMessages.HobbyNotFound);
            return _mapper.Map<GetHobbyByIdResponse>(hobby);
        }
    }
}
