using Portfolio.Contracts.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public interface IUpdateProjectService
    {
        Task<UpdateProjectResponse?> UpdateAsync(Guid id, UpdateProjectRequest request);

    }
}
