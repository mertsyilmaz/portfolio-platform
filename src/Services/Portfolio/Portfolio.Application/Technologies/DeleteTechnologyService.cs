using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public class DeleteTechnologyService : IDeleteTechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public DeleteTechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<DeleteTechnologyResponse?> DeleteAsync(Guid id)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);

            if (technology == null) 
                return null;

            await _technologyRepository.DeleteAsync(technology);

            return new DeleteTechnologyResponse
            {
                Id = technology.Id,
                IsDeleted = true
            };
        }
    }
}
