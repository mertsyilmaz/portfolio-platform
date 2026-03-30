using CV.Application.Abstractions.Persistence;
using CV.Contracts.Educations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Educations
{
    public class UpdateEducationService : IUpdateEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public UpdateEducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<UpdateEducationResponse?> UpdateAsync(Guid id, UpdateEducationRequest request)
        {
            var education = await _educationRepository.GetByIdAsync(id);

            if (education is null)
                return null;

            education.SchoolName = request.SchoolName;
            education.Department = request.Department;
            education.Degree = request.Degree;
            education.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            education.EndDate = request.EndDate.HasValue
                ? DateTime.SpecifyKind(request.EndDate.Value, DateTimeKind.Utc)
                : null;
            education.Description = request.Description;
            education.IsCurrent = request.IsCurrent;

            await _educationRepository.UpdateAsync(education);

            return new UpdateEducationResponse
            {
                Id = education.Id,
                SchoolName = education.SchoolName,
                Department = education.Department,
                Degree = education.Degree,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Description = education.Description,
                IsCurrent = education.IsCurrent
            };
        }
    }
}
