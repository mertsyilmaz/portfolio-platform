using CV.Application.Certificates;
using CV.Contracts.Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ICreateCertificateService _createService;
        private readonly IGetCertificatesService _getService;
        private readonly IGetCertificateByIdService _getByIdService;
        private readonly IUpdateCertificateService _updateService;
        private readonly IDeleteCertificateService _deleteService;

        public CertificatesController(
            ICreateCertificateService createService,
            IGetCertificatesService getService,
            IGetCertificateByIdService getByIdService,
            IUpdateCertificateService updateService,
            IDeleteCertificateService deleteService)
        {
            _createService = createService;
            _getService = getService;
            _getByIdService = getByIdService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCertificateRequest request)
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
        public async Task<IActionResult> Update(Guid id, UpdateCertificateRequest request)
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
