using CV.Application.Abstractions.Persistence;
using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public class GetCertificateByIdService : IGetCertificateByIdService
    {
        private readonly ICertificateRepository _certificateRepository;

        public GetCertificateByIdService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<GetCertificateByIdResponse?> GetByIdAsync(Guid id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);

            if(certificate == null) 
                return null;

            return new GetCertificateByIdResponse
            {
                Id = certificate.Id,
                Name = certificate.Name,
                Issuer = certificate.Issuer,
                IssuedDate = certificate.IssuedDate,
                CredentialUrl = certificate.CredentialUrl,
                CredentialId = certificate.CredentialId,
                CreatedAt = certificate.CreatedAt
            };
        }
    }
}
