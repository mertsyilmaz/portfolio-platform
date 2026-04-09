using CV.Application.Abstractions.Persistence;
using CV.Contracts.Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Certificates
{
    public class DeleteCertificateService : IDeleteCertificateService
    {
        private readonly ICertificateRepository _repository;

        public DeleteCertificateService(ICertificateRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCertificateResponse?> DeleteAsync(Guid id)
        {
            var certificate = await _repository.GetByIdAsync(id);

            if (certificate == null) 
                return null;

            await _repository.DeleteAsync(certificate);

            return new DeleteCertificateResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
