using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Projects
{
    public class GetProjectsService : IGetProjectsService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectsService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProjectsResponse>> GetAllAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return _mapper.Map<List<GetProjectsResponse>>(projects);
        }
    }
}
