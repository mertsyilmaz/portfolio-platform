using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Hobbies;
using CV.Domain.Entities;

namespace CV.Application.Hobbies
{
    public class CreateHobbyService : ICreateHobbyService
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public CreateHobbyService(IHobbyRepository hobbyRepository, IMapper mapper)
        {
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
        }

        public async Task<CreateHobbyResponse> CreateAsync(CreateHobbyRequest request)
        {
            var hobby = _mapper.Map<Hobby>(request);
            await _hobbyRepository.AddAsync(hobby);
            return _mapper.Map<CreateHobbyResponse>(hobby);
        }
    }
}
