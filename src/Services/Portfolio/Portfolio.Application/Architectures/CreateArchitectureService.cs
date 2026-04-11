using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Architectures
{
    public class CreateArchitectureService : ICreateArchitectureService
    {
        private readonly IArchitectureRepository _repository;

        public CreateArchitectureService(IArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateArchitectureResponse> CreateAsync(CreateArchitectureRequest request)
        {
            var architecture = new Portfolio.Domain.Entities.Architecture
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _repository.AddAsync(architecture);

            return new CreateArchitectureResponse
            {
                Id = architecture.Id,
                Name = architecture.Name
            };
        }
    }
}
