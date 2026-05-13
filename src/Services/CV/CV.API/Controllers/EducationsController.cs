using CV.Application.Educations;
using CV.Contracts.Educations;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly ICreateEducationService _createEducationService;
        private readonly IGetEducationsService _getEducationsService;
        private readonly IGetEducationByIdService _getEducationByIdService;
        private readonly IUpdateEducationService _updateEducationService;
        private readonly IDeleteEducationService _deleteEducationService;

        public EducationsController(
            ICreateEducationService createEducationService,
            IGetEducationsService getEducationsService,
            IGetEducationByIdService getEducationByIdService,
            IUpdateEducationService updateEducationService,
            IDeleteEducationService deleteEducationService)
        {
            _createEducationService = createEducationService;
            _getEducationsService = getEducationsService;
            _getEducationByIdService = getEducationByIdService;
            _updateEducationService = updateEducationService;
            _deleteEducationService = deleteEducationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEducationRequest request)
        {
            var response = await _createEducationService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _getEducationsService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _getEducationByIdService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEducationRequest request)
        {
            var response = await _updateEducationService.UpdateAsync(id, request);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteEducationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
