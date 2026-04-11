using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Categories;
using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public class UpdateTechnologyService : IUpdateTechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public UpdateTechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task<UpdateTechnologyResponse?> UpdateAsync(Guid id, UpdateTechnologyRequest request)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);

            if (technology == null) 
                return null;

            technology.Name = request.Name;

            await _technologyRepository.UpdateAsync(technology);

            return new UpdateTechnologyResponse { 
                Id = technology.Id,
                Name= technology.Name,
            };
        }
    }
}
