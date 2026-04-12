using CV.Application.Abstractions.Persistence;
using CV.Application.Abstractions.Services;
using CV.Contracts.PersonalInfos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.PersonalInfos
{
    public class UpdatePersonalInfoService : IUpdatePersonalInfoService
    {
        private readonly IPersonalInfoRepository _repository;
        private readonly IFileService _fileService;

        public UpdatePersonalInfoService(IPersonalInfoRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<UpdatePersonalInfoResponse?> UpdateAsync(UpdatePersonalInfoRequest request)
        {
            var entity = await _repository.GetAsync();

            if (entity == null)
                return null;

            if (request.ProfileImageId.HasValue)
            {
                var fileExists = await _fileService.ExistsAsync(request.ProfileImageId.Value);

                if (!fileExists)
                    throw new Exception("Profile image not found.");
            }

            entity.Location = request.Location;
            entity.Summary = request.Summary;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.Phone = request.Phone;
            entity.ProfileImageId = request.ProfileImageId;
            entity.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(entity);

            return new UpdatePersonalInfoResponse { 
                Id = entity.Id,
                ProfileImageId = entity.ProfileImageId,
                Phone = entity.Phone,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Location = entity.Location,
                Summary = entity.Summary,
                Title = entity.Title
            };
        }
    }
}
