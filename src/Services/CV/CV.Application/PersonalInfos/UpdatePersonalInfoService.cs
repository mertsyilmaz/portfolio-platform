using CV.Application.Abstractions.Persistence;
using CV.Contracts.PersonalInfos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.PersonalInfos
{
    public class UpdatePersonalInfoService : IUpdatePersonalInfoService
    {
        private readonly IPersonalInfoRepository _repository;

        public UpdatePersonalInfoService(IPersonalInfoRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdatePersonalInfoResponse?> UpdateAsync(UpdatePersonalInfoRequest request)
        {
            var entity = await _repository.GetAsync();

            if (entity == null)
                return null;
            
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
