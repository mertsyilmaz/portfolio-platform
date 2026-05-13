using CV.Application.PersonalInfos;
using CV.Contracts.PersonalInfos;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfosController : ControllerBase
    {
        private readonly ICreatePersonalInfoService _createService;
        private readonly IGetPersonalInfosService _getService;
        private readonly IUpdatePersonalInfoService _updateService;
        private readonly IDeletePersonalInfoService _deleteService;

        public PersonalInfosController(
            ICreatePersonalInfoService createService,
            IGetPersonalInfosService getService,
            IUpdatePersonalInfoService updateService,
            IDeletePersonalInfoService deleteService)
        {
            _createService = createService;
            _getService = getService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonalInfoRequest request)
        {
            var result = await _createService.CreateAsync(request);
            return CreatedAtAction(nameof(Get), new { }, result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _getService.GetAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonalInfoRequest request)
        {
            var result = await _updateService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await _deleteService.DeleteAsync();
            return NoContent();
        }
    }
}
