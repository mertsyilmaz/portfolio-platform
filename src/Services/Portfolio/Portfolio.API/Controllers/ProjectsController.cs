using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Projects;
using Portfolio.Contracts.Projects;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ICreateProjectService _createProjectService;
        private readonly IGetProjectsService _getProjectsService;
        private readonly IGetProjectByIdService _getProjectByIdService;
        private readonly IUpdateProjectService _updateProjectService;
        private readonly IDeleteProjectService _deleteProjectService;

        public ProjectsController(
            ICreateProjectService createProjectService,
            IGetProjectsService getProjectsService,
            IGetProjectByIdService getProjectByIdService,
            IUpdateProjectService updateProjectService,
            IDeleteProjectService deleteProjectService)
        {
            _createProjectService = createProjectService;
            _getProjectsService = getProjectsService;
            _getProjectByIdService = getProjectByIdService;
            _updateProjectService = updateProjectService;
            _deleteProjectService = deleteProjectService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            var result = await _createProjectService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getProjectsService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getProjectByIdService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProjectRequest request)
        {
            var result = await _updateProjectService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteProjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
