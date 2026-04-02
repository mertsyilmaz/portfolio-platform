using CV.Application.Abstractions.Persistence;
using CV.Contracts.PersonalInfos;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.PersonalInfos
{
    public class CreatePersonalInfoService : ICreatePersonalInfoService
    {
        private readonly IPersonalInfoRepository _repository;

        public CreatePersonalInfoService(IPersonalInfoRepository personalInfoRepository)
        {
            _repository = personalInfoRepository;
        }

        public async Task<CreatePersonalInfoResponse> CreateAsync(CreatePersonalInfoRequest request)
        {
            var existing = await _repository.GetAsync();
            if (existing != null)
                throw new Exception("Personal info already exists");

            var entity = new PersonalInfo
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Title = request.Title,
                Summary = request.Summary,
                Email = request.Email,
                Phone = request.Phone,
                Location = request.Location,
                ProfileImageId = request.ProfileImageId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);

            return new CreatePersonalInfoResponse { 
                 Id = entity.Id,
                 FirstName = entity.FirstName,
                 LastName= entity.LastName,
                 Title= entity.Title
            };
        }
    }
}
