using CV.Application.Abstractions.Persistence;
using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public class UpdateCertificateService : IUpdateCertificateService
    {
        private readonly ICertificateRepository _certificateRepository;

        public UpdateCertificateService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<UpdateCertificateResponse?> UpdateAsync(Guid id, UpdateCertificateRequest request)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);

            if (certificate == null) 
                return null;

            certificate.Name = request.Name;
            certificate.Issuer = request.Issuer;
            certificate.CredentialUrl = request.CredentialUrl;
            certificate.CredentialId = request.CredentialId;
            certificate.IssuedDate = request.IssuedDate;

            await _certificateRepository.UpdateAsync(certificate);

            return new UpdateCertificateResponse
            {
                Id = certificate.Id,
                Name = certificate.Name,
                Issuer = certificate.Issuer,
                CredentialId = certificate.CredentialId,
                CredentialUrl = certificate.CredentialUrl,
                IssuedDate = certificate.IssuedDate
            };
        }
    }
}
