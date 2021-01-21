using System.Threading;
using System.Threading.Tasks;

namespace TimeTracker.Client.Services
{
    public interface IValidateUser
    {
        Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken);

        Task<bool> IsUsernameUnique(string username, CancellationToken cancellationToken);
    }
}