using CV.Application.Abstractions.Persistence;
using CV.Contracts.Certificates;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public class CreateCertificateService : ICreateCertificateService
    {
        private readonly ICertificateRepository _certificateRepository;

        public CreateCertificateService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<CreateCertificateResponse> CreateAsync(CreateCertificateRequest request)
        {
            var certificate = new Certificate
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Issuer = request.Issuer,
                IssuedDate = request.IssuedDate,
                CredentialId = request.CredentialId,
                CredentialUrl = request.CredentialUrl,
                CreatedAt = DateTime.UtcNow
            };

            await _certificateRepository.AddAsync(certificate);

            return new CreateCertificateResponse { 
                Id = certificate.Id,
                Name = request.Name,
                Issuer = certificate.Issuer
            };
        }
    }
}
