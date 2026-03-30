using CV.Application.Abstractions.Persistence;
using CV.Contracts.Educations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Educations
{
    public class GetEducationsService : IGetEducationsService
    {
        private readonly IEducationRepository _educationRepository;

        public GetEducationsService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<List<GetEducationsResponse>> GetAllAsync()
        {
            var educations = await _educationRepository.GetAllAsync();

            return educations.Select(x => new GetEducationsResponse
            {
                Id = x.Id,
                SchoolName = x.SchoolName,
                Department = x.Department,
                Degree = x.Degree,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsCurrent = x.IsCurrent
            }).ToList();
        }
    }
}
