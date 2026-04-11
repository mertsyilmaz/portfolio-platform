using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Projects
{
    public class DeleteProjectService : IDeleteProjectService
    {
        private readonly IProjectRepository _repository;

        public DeleteProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteProjectResponse?> DeleteAsync(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null) 
                return null;

            await _repository.DeleteAsync(project);

            return new DeleteProjectResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
