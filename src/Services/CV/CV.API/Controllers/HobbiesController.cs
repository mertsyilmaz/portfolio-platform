using CV.Application.Hobbies;
using CV.Contracts.Hobbies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly ICreateHobbyService _createService;
        private readonly IGetHobbiesService _getService;
        private readonly IGetHobbyByIdService _getByIdService;
        private readonly IUpdateHobbyService _updateService;
        private readonly IDeleteHobbyService _deleteService;

        public HobbiesController(
            ICreateHobbyService createService,
            IGetHobbiesService getService,
            IGetHobbyByIdService getByIdService,
            IUpdateHobbyService updateService,
            IDeleteHobbyService deleteService)
        {
            _createService = createService;
            _getService = getService;
            _getByIdService = getByIdService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHobbyRequest request)
        {
            var result = await _createService.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getByIdService.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateHobbyRequest request)
        {
            var result = await _updateService.UpdateAsync(id, request);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteService.DeleteAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
