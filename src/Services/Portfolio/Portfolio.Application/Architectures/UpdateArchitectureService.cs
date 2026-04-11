using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Architectures
{
    public class UpdateArchitectureService : IUpdateArchitectureService
    {
        private readonly IArchitectureRepository _repository;

        public UpdateArchitectureService(IArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateArchitectureResponse> UpdateAsync(Guid id, UpdateArchitectureRequest request)
        {
            var architecture = await _repository.GetByIdAsync(id);

            if (architecture == null)
                return null;

            architecture.Name = request.Name;

            await _repository.UpdateAsync(architecture);

            return new UpdateArchitectureResponse
            {
                Id = architecture.Id,
                Name = request.Name
            };
        }
    }
}
