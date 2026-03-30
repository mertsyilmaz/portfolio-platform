using CV.Application.Skills;
using CV.Contracts.Skills;
using Microsoft.AspNetCore.Http;
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

        public SkillsController(IDeleteSkillService deleteSkillService, IUpdateSkillService updateSkillService, IGetSkillByIdService getSkillByIdService, IGetSkillsService getSkillsService, ICreateSkillService createSkillService)
        {
            _deleteSkillService = deleteSkillService;
            _updateSkillService = updateSkillService;
            _getSkillByIdService = getSkillByIdService;
            _getSkillsService = getSkillsService;
            _createSkillService = createSkillService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSkillRequest request)
        {
            var response = await _createSkillService.CreateAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _getSkillsService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _getSkillByIdService.GetByIdAsync(id);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSkillRequest request)
        {
            var response = await _updateSkillService.UpdateAsync(id, request);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _deleteSkillService.DeleteAsync(id);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
