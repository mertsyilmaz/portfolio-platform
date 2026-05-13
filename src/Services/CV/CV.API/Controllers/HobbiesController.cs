using CV.Application.Hobbies;
using CV.Contracts.Hobbies;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly ICreateHobbyService _createHobbyService;
        private readonly IGetHobbiesService _getHobbiesService;
        private readonly IGetHobbyByIdService _getHobbyByIdService;
        private readonly IUpdateHobbyService _updateHobbyService;
        private readonly IDeleteHobbyService _deleteHobbyService;

        public HobbiesController(
            ICreateHobbyService createHobbyService,
            IGetHobbiesService getHobbiesService,
            IGetHobbyByIdService getHobbyByIdService,
            IUpdateHobbyService updateHobbyService,
            IDeleteHobbyService deleteHobbyService)
        {
            _createHobbyService = createHobbyService;
            _getHobbiesService = getHobbiesService;
            _getHobbyByIdService = getHobbyByIdService;
            _updateHobbyService = updateHobbyService;
            _deleteHobbyService = deleteHobbyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHobbyRequest request)
        {
            var result = await _createHobbyService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getHobbiesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getHobbyByIdService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateHobbyRequest request)
        {
            var result = await _updateHobbyService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteHobbyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
