using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Architectures
{
    public class GetArchitectureByIdService : IGetArchitectureByIdService
    {
        private readonly IArchitectureRepository _repository;

        public GetArchitectureByIdService(IArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetArchitectureByIdResponse> GetByIdAsync(Guid id)
        {
            var architecture = await _repository.GetByIdAsync(id);

            if (architecture == null)
                return null;

            return new GetArchitectureByIdResponse
            {
                Id = architecture.Id,
                Name = architecture.Name
            };
        }
    }
}
