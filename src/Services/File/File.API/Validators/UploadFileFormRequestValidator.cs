using File.API.Models;
using File.Application.Common.Constants;
using File.Application.Common.Exceptions;
using FluentValidation;

namespace File.API.Validators
{
    public class UploadFileFormRequestValidator : AbstractValidator<UploadFileFormRequest>
    {
        public UploadFileFormRequestValidator()
        {
            RuleFor(x => x.File)
                .NotNull()
                .WithMessage(ErrorMessages.UploadedFileIsRequired);

            RuleFor(x => x.File.Length)
                .GreaterThan(0)
                .When(x => x.File is not null)
                .WithMessage(ErrorMessages.UploadedFileIsRequired);

            RuleFor(x => x.FolderName)
                .NotEmpty()
                .WithMessage(ErrorMessages.FolderNameIsRequired)
                .Must(x => !string.IsNullOrWhiteSpace(x) && FileFolderNames.AllowedFolders.Contains(x.ToLowerInvariant()))
                .WithMessage(ErrorMessages.InvalidFolderName);
        }
    }
}
