using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Technologies;
using Portfolio.Contracts.Technologies;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private readonly ICreateTechnologyService _createTechnologyService;
        private readonly IGetTechnologiesService _getTechnologiesService;
        private readonly IGetTechnologyByIdService _getTechnologyByIdService;
        private readonly IUpdateTechnologyService _updateTechnologyService;
        private readonly IDeleteTechnologyService _deleteTechnologyService;

        public TechnologiesController(
            ICreateTechnologyService createTechnologyService,
            IGetTechnologiesService getTechnologiesService,
            IGetTechnologyByIdService getTechnologyByIdService,
            IUpdateTechnologyService updateTechnologyService,
            IDeleteTechnologyService deleteTechnologyService)
        {
            _createTechnologyService = createTechnologyService;
            _getTechnologiesService = getTechnologiesService;
            _getTechnologyByIdService = getTechnologyByIdService;
            _updateTechnologyService = updateTechnologyService;
            _deleteTechnologyService = deleteTechnologyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTechnologyRequest request)
        {
            var result = await _createTechnologyService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getTechnologiesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getTechnologyByIdService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateTechnologyRequest request)
        {
            var result = await _updateTechnologyService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteTechnologyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
