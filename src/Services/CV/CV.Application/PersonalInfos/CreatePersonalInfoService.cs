using CV.Application.Abstractions.Persistence;
using CV.Application.Abstractions.Services;
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
        private readonly IFileService _fileService;

        public CreatePersonalInfoService(IPersonalInfoRepository personalInfoRepository, IFileService fileService)
        {
            _repository = personalInfoRepository;
            _fileService = fileService;
        }

        public async Task<CreatePersonalInfoResponse> CreateAsync(CreatePersonalInfoRequest request)
        {
            var existing = await _repository.GetAsync();
            if (existing != null)
                throw new Exception("Personal info already exists");

            if (request.ProfileImageId.HasValue)
            {
                var fileExists = await _fileService.ExistsAsync(request.ProfileImageId.Value);

                if (!fileExists)
                    throw new Exception("Profile image not found.");
            }

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
