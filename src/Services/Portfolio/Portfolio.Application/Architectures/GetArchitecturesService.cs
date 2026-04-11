using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Architectures
{
    public class GetArchitecturesService : IGetArchitecturesService
    {
        private readonly IArchitectureRepository _repository;

        public GetArchitecturesService(IArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetArchitecturesResponse>> GetAllAsync()
        {
            var architectures = await _repository.GetAllAsync();

            return architectures.Select(x => new GetArchitecturesResponse 
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
