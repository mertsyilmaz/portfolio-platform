using CV.Application.Languages;
using CV.Contracts.Languages;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ICreateLanguageService _createLanguageService;
        private readonly IGetLanguagesService _getLanguagesService;
        private readonly IGetLanguageByIdService _getLanguageByIdService;
        private readonly IUpdateLanguageService _updateLanguageService;
        private readonly IDeleteLanguageService _deleteLanguageService;

        public LanguagesController(
            ICreateLanguageService createLanguageService,
            IGetLanguagesService getLanguagesService,
            IGetLanguageByIdService getLanguageByIdService,
            IUpdateLanguageService updateLanguageService,
            IDeleteLanguageService deleteLanguageService)
        {
            _createLanguageService = createLanguageService;
            _getLanguagesService = getLanguagesService;
            _getLanguageByIdService = getLanguageByIdService;
            _updateLanguageService = updateLanguageService;
            _deleteLanguageService = deleteLanguageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguageRequest request)
        {
            var result = await _createLanguageService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getLanguagesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getLanguageByIdService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateLanguageRequest request)
        {
            var result = await _updateLanguageService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteLanguageService.DeleteAsync(id);
            return NoContent();
        }
    }
}
