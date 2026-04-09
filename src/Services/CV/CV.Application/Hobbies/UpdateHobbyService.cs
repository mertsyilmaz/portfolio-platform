using CV.Application.Abstractions.Persistence;
using CV.Contracts.Hobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Hobbies
{
    public class UpdateHobbyService : IUpdateHobbyService
    {
        private readonly IHobbyRepository _repository;

        public UpdateHobbyService(IHobbyRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateHobbyResponse?> UpdateAsync(Guid id, UpdateHobbyRequest request)
        {
            var hobby = await _repository.GetByIdAsync(id);

            if (hobby == null) 
                return null;

            hobby.Name = request.Name;
            hobby.Description = request.Description;

            await _repository.UpdateAsync(hobby);

            return new UpdateHobbyResponse
            {
                Id = hobby.Id,
                Name = hobby.Name,
                Description = hobby.Description
            };
        }
    }
}
