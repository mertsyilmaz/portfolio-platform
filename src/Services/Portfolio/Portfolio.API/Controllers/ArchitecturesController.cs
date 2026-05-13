using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Architectures;
using Portfolio.Contracts.Architectures;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchitecturesController : ControllerBase
    {
        private readonly ICreateArchitectureService _createArchitectureService;
        private readonly IGetArchitecturesService _getArchitecturesService;
        private readonly IGetArchitectureByIdService _getArchitectureByIdService;
        private readonly IUpdateArchitectureService _updateArchitectureService;
        private readonly IDeleteArchitectureService _deleteArchitectureService;

        public ArchitecturesController(
            ICreateArchitectureService createArchitectureService,
            IGetArchitecturesService getArchitecturesService,
            IGetArchitectureByIdService getArchitectureByIdService,
            IUpdateArchitectureService updateArchitectureService,
            IDeleteArchitectureService deleteArchitectureService)
        {
            _createArchitectureService = createArchitectureService;
            _getArchitecturesService = getArchitecturesService;
            _getArchitectureByIdService = getArchitectureByIdService;
            _updateArchitectureService = updateArchitectureService;
            _deleteArchitectureService = deleteArchitectureService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArchitectureRequest request)
        {
            var result = await _createArchitectureService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getArchitecturesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getArchitectureByIdService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateArchitectureRequest request)
        {
            var result = await _updateArchitectureService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteArchitectureService.DeleteAsync(id);
            return NoContent();
        }
    }
}
