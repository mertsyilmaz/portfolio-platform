using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Technologies;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public class CreateTechnologyService : ICreateTechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public CreateTechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task<CreateTechnologyResponse> CreateAsync(CreateTechnologyRequest request)
        {
            var technology = new Technology
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _technologyRepository.AddAsync(technology);

            return new CreateTechnologyResponse
            {
                Id = technology.Id,
                Name = request.Name
            };
        }
    }
}
