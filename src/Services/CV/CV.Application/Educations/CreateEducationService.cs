using CV.Application.Abstractions.Persistence;
using CV.Contracts.Educations;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Educations
{
    public class CreateEducationService : ICreateEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public CreateEducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<CreateEducationResponse> CreateAsync(CreateEducationRequest request)
        {
            var education = new Education
            {
                Id = Guid.NewGuid(),
                SchoolName = request.SchoolName,
                Department = request.Department,
                Degree = request.Degree,
                StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc),
                EndDate = request.EndDate.HasValue
                    ? DateTime.SpecifyKind(request.EndDate.Value, DateTimeKind.Utc)
                    : null,
                Description = request.Description,
                IsCurrent = request.IsCurrent,
                CreatedAt = DateTime.UtcNow
            };

            await _educationRepository.AddAsync(education);

            return new CreateEducationResponse
            {
                Id = education.Id,
                SchoolName = education.SchoolName,
                Department = education.Department
            };
        }
    }
}
