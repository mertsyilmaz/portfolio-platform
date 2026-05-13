using CV.Application.Certificates;
using CV.Contracts.Certificates;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ICreateCertificateService _createCertificateService;
        private readonly IGetCertificatesService _getCertificatesService;
        private readonly IGetCertificateByIdService _getCertificateByIdService;
        private readonly IUpdateCertificateService _updateCertificateService;
        private readonly IDeleteCertificateService _deleteCertificateService;

        public CertificatesController(
            ICreateCertificateService createCertificateService,
            IGetCertificatesService getCertificatesService,
            IGetCertificateByIdService getCertificateByIdService,
            IUpdateCertificateService updateCertificateService,
            IDeleteCertificateService deleteCertificateService)
        {
            _createCertificateService = createCertificateService;
            _getCertificatesService = getCertificatesService;
            _getCertificateByIdService = getCertificateByIdService;
            _updateCertificateService = updateCertificateService;
            _deleteCertificateService = deleteCertificateService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCertificateRequest request)
        {
            var response = await _createCertificateService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _getCertificatesService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _getCertificateByIdService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCertificateRequest request)
        {
            var response = await _updateCertificateService.UpdateAsync(id, request);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteCertificateService.DeleteAsync(id);
            return NoContent();
        }
    }
}
