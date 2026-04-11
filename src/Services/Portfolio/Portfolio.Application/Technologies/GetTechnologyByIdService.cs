using Portfolio.Application.Abstractions.Persistence;

using Portfolio.Contracts.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Technologies
{
    public class GetTechnologyByIdService : IGetTechnologyByIdService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public GetTechnologyByIdService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task<GetTechnologyByIdResponse?> GetByIdAsync(Guid id)
        {
            var category  = await _technologyRepository.GetByIdAsync(id);

            if (category == null) 
                return null;

            return new GetTechnologyByIdResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
