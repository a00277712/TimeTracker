using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Client.Services;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Validators
{
    public class ProjectValidator : AbstractValidator<ProjectDto>
    {
        private readonly IValidateProject validateProject;

        public ProjectValidator(IValidateProject validate)
        {
            validateProject = validate;

            RuleFor(x => x.Code)
                .MustAsync(CodeUnique)
                .When(x => x.Code != x.OldCode)
                .WithMessage("Code must be unique");

            RuleFor(x => x.Title)
                .MustAsync(TitleUnique)
                .When(x => x.Title != x.OldTitle)
                .WithMessage("Title must be unique");
        }

        private async Task<bool> CodeUnique(string code, CancellationToken token)
        {
            return await validateProject.IsCodeUnique(code, token);
        }

        private async Task<bool> TitleUnique(string title, CancellationToken token)
        {
            return await validateProject.IsTitleUnique(title, token);
        }
    }
}
