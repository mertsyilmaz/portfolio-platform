using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CV.Application.Experiences;
using CV.Contracts.Experiences;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly ICreateExperienceService _createExperienceService;
        private readonly IGetExperienceService _getExperienceService;
        private readonly IGetExperienceByIdService _getExperienceByIdService;
        private readonly IUpdateExperienceService _updateExperienceService;
        private readonly IDeleteExperienceService _deleteExperienceService;

        public ExperiencesController(ICreateExperienceService createExperienceService, IGetExperienceService getExperienceService, IGetExperienceByIdService getExperienceByIdService, IUpdateExperienceService updateExperienceService, IDeleteExperienceService deleteExperienceService)
        {
            _createExperienceService = createExperienceService;
            _getExperienceService = getExperienceService;
            _getExperienceByIdService = getExperienceByIdService;
            _updateExperienceService = updateExperienceService;
            _deleteExperienceService = deleteExperienceService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExperienceRequest request)
        {
            var response = await _createExperienceService.CreateAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _getExperienceService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _getExperienceByIdService.GetByIdAsync(id);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExperienceRequest request)
        {
            var response = await _updateExperienceService.UpdateAsync(id, request);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _deleteExperienceService.DeleteAsync(id);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
