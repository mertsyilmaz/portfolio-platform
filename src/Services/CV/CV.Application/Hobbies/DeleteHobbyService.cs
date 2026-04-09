using CV.Application.Abstractions.Persistence;
using CV.Contracts.Hobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Hobbies
{
    public class DeleteHobbyService : IDeleteHobbyService
    {
        private readonly IHobbyRepository _repository;

        public DeleteHobbyService(IHobbyRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteHobbyResponse?> DeleteAsync(Guid id)
        {
            var hobby = await _repository.GetByIdAsync(id);

            if (hobby == null) 
                return null;

            await _repository.DeleteAsync(hobby);

            return new DeleteHobbyResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
