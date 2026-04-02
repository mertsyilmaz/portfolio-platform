using CV.Application.Abstractions.Persistence;
using CV.Contracts.PersonalInfos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.PersonalInfos
{
    public class DeletePersonalInfoService : IDeletePersonalInfoService
    {
        private readonly IPersonalInfoRepository _repository;

        public DeletePersonalInfoService(IPersonalInfoRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeletePersonalInfoResponse?> DeleteAsync()
        {
            var entity = await _repository.GetAsync();

            if (entity == null) 
                return null;

            await _repository.DeleteAsync(entity);

            return new DeletePersonalInfoResponse
            {
                Id = entity.Id,
                IsDeleted = true
            };
            
        }
    }
}
