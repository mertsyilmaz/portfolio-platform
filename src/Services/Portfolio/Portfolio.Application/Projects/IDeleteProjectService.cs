using Portfolio.Contracts.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public interface IDeleteProjectService
    {
        Task<DeleteProjectResponse?> DeleteAsync(Guid id);

    }
}
