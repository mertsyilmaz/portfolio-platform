using CV.Application.Abstractions.Persistence;
using CV.Contracts.PersonalInfos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.PersonalInfos
{
    public class GetPersonalInfoService : IGetPersonalInfosService
    {
        private readonly IPersonalInfoRepository _repository;

        public GetPersonalInfoService(IPersonalInfoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPersonalInfoResponse?> GetAsync()
        {
            var entity = await _repository.GetAsync();

            if(entity == null)
                return null;

            return new GetPersonalInfoResponse
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Title = entity.Title,
                Summary = entity.Summary,
                Email = entity.Email,
                Phone = entity.Phone,
                Location = entity.Location,
                ProfileImageId = entity.ProfileImageId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
            
        }
    }
}
