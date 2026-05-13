using CV.Application.SocialLinks;
using CV.Contracts.SocialLinks;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : ControllerBase
    {
        private readonly ICreateSocialLinkService _createSocialLinkService;
        private readonly IGetSocialLinksService _getSocialLinksService;
        private readonly IGetSocialLinkByIdService _getSocialLinkByIdService;
        private readonly IUpdateSocialLinkService _updateSocialLinkService;
        private readonly IDeleteSocialLinkService _deleteSocialLinkService;

        public SocialLinksController(
            ICreateSocialLinkService createSocialLinkService,
            IGetSocialLinksService getSocialLinksService,
            IGetSocialLinkByIdService getSocialLinkByIdService,
            IUpdateSocialLinkService updateSocialLinkService,
            IDeleteSocialLinkService deleteSocialLinkService)
        {
            _createSocialLinkService = createSocialLinkService;
            _getSocialLinksService = getSocialLinksService;
            _getSocialLinkByIdService = getSocialLinkByIdService;
            _updateSocialLinkService = updateSocialLinkService;
            _deleteSocialLinkService = deleteSocialLinkService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialLinkRequest request)
        {
            var result = await _createSocialLinkService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getSocialLinksService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getSocialLinkByIdService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateSocialLinkRequest request)
        {
            var result = await _updateSocialLinkService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteSocialLinkService.DeleteAsync(id);
            return NoContent();
        }
    }
}
