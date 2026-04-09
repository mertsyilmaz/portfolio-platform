using CV.Application.Abstractions.Persistence;
using CV.Contracts.Hobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Hobbies
{
    public class GetHobbiesService : IGetHobbiesService
    {
        private readonly IHobbyRepository _repository;

        public GetHobbiesService(IHobbyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetHobbiesResponse>> GetAllAsync()
        {
            var hobbies = await _repository.GetAllAsync();

            return hobbies.Select(x => new GetHobbiesResponse{
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }
    }
}
