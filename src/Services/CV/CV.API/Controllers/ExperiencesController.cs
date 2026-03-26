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

        public ExperiencesController(ICreateExperienceService createExperienceService)
        {
            _createExperienceService = createExperienceService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExperienceRequest request)
        {
            var response = await _createExperienceService.CreateAsync(request);
            return Ok(response);
        }
    }
}
