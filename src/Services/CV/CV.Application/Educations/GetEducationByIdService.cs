using CV.Application.Abstractions.Persistence;
using CV.Contracts.Educations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Educations
{
    public class GetEducationByIdService : IGetEducationByIdService
    {
        private readonly IEducationRepository _educationRepository;

        public GetEducationByIdService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<GetEducationByIdResponse?> GetByIdAsync(Guid id)
        {
            var education = await _educationRepository.GetByIdAsync(id);

            if (education is null)
                return null;

            return new GetEducationByIdResponse
            {
                Id = education.Id,
                SchoolName = education.SchoolName,
                Department = education.Department,
                Degree = education.Degree,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Description = education.Description,
                IsCurrent = education.IsCurrent,
                CreatedAt = education.CreatedAt
            };
        }
    }
}
