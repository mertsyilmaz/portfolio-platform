using CV.Application.Abstractions.Persistence;
using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public class GetCertificatesService : IGetCertificatesService
    {
        private readonly ICertificateRepository _certificateRepository;

        public GetCertificatesService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<List<GetCertificatesResponse>> GetAllAsync()
        {
            var certificates = await _certificateRepository.GetAllAsync();

            return certificates.Select(x => new GetCertificatesResponse { 
                Id = x.Id,
                Name = x.Name,
                Issuer = x.Issuer
            }).ToList();
        }
    }
}
