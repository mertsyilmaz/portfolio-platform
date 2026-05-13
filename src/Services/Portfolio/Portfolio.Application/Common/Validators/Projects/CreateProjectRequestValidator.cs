using FluentValidation;
using Portfolio.Application.Common.Validation;
using Portfolio.Contracts.Projects;

namespace Portfolio.Application.Common.Validators.Projects
{
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectRequestValidator()
        {
            RuleFor(x => x.Name).MustBeRequiredText("Name", 200);
            RuleFor(x => x.Summary).MustBeRequiredText("Summary", 500);
            RuleFor(x => x.Description).MustBeRequiredContent("Description");
            RuleFor(x => x.ProjectUrl).MustBeRequiredText("Project url", 500);
            RuleFor(x => x.GithubUrl).MustBeRequiredText("Github url", 500);
            RuleFor(x => x.DisplayOrder).MustBeNonNegative("Display order");
            RuleFor(x => x.CategoryIds).MustBeRequiredCollection("Category ids");
            RuleFor(x => x.TechnologyIds).MustBeRequiredCollection("Technology ids");
            RuleFor(x => x.ArchitectureIds).MustBeRequiredCollection("Architecture ids");
        }
    }
}
