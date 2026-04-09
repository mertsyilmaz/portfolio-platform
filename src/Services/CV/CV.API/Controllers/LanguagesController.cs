using CV.Application.Languages;
using CV.Contracts.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ICreateLanguageService _createService;
        private readonly IGetLanguagesService _getService;
        private readonly IGetLanguageByIdService _getByIdService;
        private readonly IUpdateLanguageService _updateService;
        private readonly IDeleteLanguageService _deleteService;

        public LanguagesController(
            ICreateLanguageService createService,
            IGetLanguagesService getService,
            IGetLanguageByIdService getByIdService,
            IUpdateLanguageService updateService,
            IDeleteLanguageService deleteService)
        {
            _createService = createService;
            _getService = getService;
            _getByIdService = getByIdService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguageRequest request)
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
        public async Task<IActionResult> Update(Guid id, UpdateLanguageRequest request)
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
