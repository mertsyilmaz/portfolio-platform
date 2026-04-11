using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public class GetTechnologiesService : IGetTechnologiesService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public GetTechnologiesService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task<List<GetTechnologiesResponse>> GetAllAsync()
        {
            var technologies = await _technologyRepository.GetAllAsync();
            return technologies.Select(x => new GetTechnologiesResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
