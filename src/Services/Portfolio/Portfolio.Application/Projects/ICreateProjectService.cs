using Portfolio.Contracts.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public interface ICreateProjectService
    {
        Task<CreateProjectResponse> CreateAsync(CreateProjectRequest request);
    }
}
