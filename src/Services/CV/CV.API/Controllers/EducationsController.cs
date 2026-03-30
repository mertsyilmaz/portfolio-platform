using CV.Application.Educations;
using CV.Contracts.Educations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly ICreateEducationService _createEducationService;
        private readonly IGetEducationByIdService _getEducationByIdService;
        private readonly IGetEducationsService _getEducationsService;
        private readonly IUpdateEducationService _updateEducationService;
        private readonly IDeleteEducationService _deleteEducationService;

        public EducationsController(IDeleteEducationService deleteEducationService, IUpdateEducationService updateEducationService, IGetEducationsService getEducationsService , IGetEducationByIdService getEducationByIdService, ICreateEducationService createEducationService)
        {
            _deleteEducationService = deleteEducationService;
            _updateEducationService = updateEducationService;
            _getEducationsService = getEducationsService;
            _getEducationByIdService = getEducationByIdService;
            _createEducationService = createEducationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEducationRequest request)
        {
            var response = await _createEducationService.CreateAsync(request);
            return Ok(response);
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

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEducationRequest request)
        {
            var response = await _updateEducationService.UpdateAsync(id, request);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _deleteEducationService.DeleteAsync(id);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
