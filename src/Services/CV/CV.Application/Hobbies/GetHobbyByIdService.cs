using CV.Application.Abstractions.Persistence;
using CV.Contracts.Hobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Hobbies
{
    public class GetHobbyByIdService : IGetHobbyByIdService
    {
        private readonly IHobbyRepository _repository;

        public GetHobbyByIdService(IHobbyRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetHobbyByIdResponse?> GetByIdAsync(Guid id)
        {
            var hobby = await _repository.GetByIdAsync(id);

            if (hobby == null) 
                return null;

            return new GetHobbyByIdResponse
            {
                Id = hobby.Id,
                Name = hobby.Name,
                Description = hobby.Description,
                CreatedAt = hobby.CreatedAt
            };
        }
    }
}
