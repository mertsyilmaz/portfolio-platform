using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Architectures
{
    public class DeleteArchitectureService : IDeleteArchitectureService
    {
        private readonly IArchitectureRepository _repository;

        public DeleteArchitectureService(IArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteArchitectureResponse> DeleteAsync(Guid id)
        {
            var architecture = await _repository.GetByIdAsync(id);

            if (architecture == null)
                return null;

            await _repository.DeleteAsync(architecture);

            return new DeleteArchitectureResponse
            {
                Id = architecture.Id,
                IsDeleted = true
            };
        }
    }
}
