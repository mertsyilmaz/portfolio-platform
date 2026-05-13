using CV.Application.Skills;
using CV.Contracts.Skills;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ICreateSkillService _createSkillService;
        private readonly IGetSkillsService _getSkillsService;
        private readonly IGetSkillByIdService _getSkillByIdService;
        private readonly IUpdateSkillService _updateSkillService;
        private readonly IDeleteSkillService _deleteSkillService;

        public SkillsController(
            ICreateSkillService createSkillService,
            IGetSkillsService getSkillsService,
            IGetSkillByIdService getSkillByIdService,
            IUpdateSkillService updateSkillService,
            IDeleteSkillService deleteSkillService)
        {
            _createSkillService = createSkillService;
            _getSkillsService = getSkillsService;
            _getSkillByIdService = getSkillByIdService;
            _updateSkillService = updateSkillService;
            _deleteSkillService = deleteSkillService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillRequest request)
        {
            var result = await _createSkillService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getSkillsService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getSkillByIdService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateSkillRequest request)
        {
            var result = await _updateSkillService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteSkillService.DeleteAsync(id);
            return NoContent();
        }
    }
}
