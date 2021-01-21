using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Client.Services;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        private readonly IValidateUser validateUser;

        public UserValidator(IValidateUser validate)
        {
            validateUser = validate;

            RuleFor(x => x.Email)
                .MustAsync(EmailUnique)
                .When(x => x.Email != x.OldEmail)
                .WithMessage("Email must be unique");

            RuleFor(x => x.UserName)
                .MustAsync(UsernameUnique)
                .When(x => x.UserName != x.OldUsername)
                .WithMessage("Username must be unique");
        }

        private async Task<bool> EmailUnique(string email, CancellationToken token)
        {
            return await validateUser.IsEmailUnique(email, token);
        }

        private async Task<bool> UsernameUnique(string username, CancellationToken token)
        {
            return await validateUser.IsUsernameUnique(username, token);
        }
    }
}
