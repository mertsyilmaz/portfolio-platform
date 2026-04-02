using CV.Application.SocialLinks;
using CV.Contracts.SocialLinks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : ControllerBase
    {
        private readonly ICreateSocialLinkService _createService;
        private readonly IGetSocialLinksService _getService;
        private readonly IGetSocialLinkByIdService _getByIdService;
        private readonly IUpdateSocialLinkService _updateService;
        private readonly IDeleteSocialLinkService _deleteService;

        public SocialLinksController(
            ICreateSocialLinkService createService,
            IGetSocialLinksService getService,
            IGetSocialLinkByIdService getByIdService,
            IUpdateSocialLinkService updateService,
            IDeleteSocialLinkService deleteService)
        {
            _createService = createService;
            _getService = getService;
            _getByIdService = getByIdService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialLinkRequest request)
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
        public async Task<IActionResult> Update(Guid id, UpdateSocialLinkRequest request)
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
