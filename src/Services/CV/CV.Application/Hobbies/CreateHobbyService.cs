using CV.Application.Abstractions.Persistence;
using CV.Contracts.Hobbies;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Hobbies
{
    public class CreateHobbyService : ICreateHobbyService
    {
        private readonly IHobbyRepository _repository;

        public CreateHobbyService(IHobbyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateHobbyResponse> CreateAsync(CreateHobbyRequest request)
        {
            var hobby = new Hobby
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(hobby);

            return new CreateHobbyResponse
            {
                Name = hobby.Name,
                Id = hobby.Id
            };
        }
    }
}
