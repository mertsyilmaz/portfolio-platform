using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Hobbies;

namespace CV.Application.Hobbies
{
    public class GetHobbiesService : IGetHobbiesService
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public GetHobbiesService(IHobbyRepository hobbyRepository, IMapper mapper)
        {
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
        }

        public async Task<List<GetHobbiesResponse>> GetAllAsync()
        {
            var hobbies = await _hobbyRepository.GetAllAsync();
            return _mapper.Map<List<GetHobbiesResponse>>(hobbies);
        }
    }
}
