using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Projects
{
    public class GetProjectByIdService : IGetProjectByIdService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectByIdService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<GetProjectByIdResponse> GetByIdAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(project, ErrorMessages.ProjectNotFound);

            return _mapper.Map<GetProjectByIdResponse>(project);
        }
    }
}
