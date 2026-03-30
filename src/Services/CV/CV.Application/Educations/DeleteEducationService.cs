using CV.Application.Abstractions.Persistence;
using CV.Contracts.Educations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Educations
{
    public class DeleteEducationService : IDeleteEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public DeleteEducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<DeleteEducationResponse?> DeleteAsync(Guid id)
        {
            var education = await _educationRepository.GetByIdAsync(id);

            if (education is null)
                return null;

            await _educationRepository.DeleteAsync(education);

            return new DeleteEducationResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
