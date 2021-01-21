using System.Threading;
using System.Threading.Tasks;

namespace TimeTracker.Client.Services
{
    public interface IValidateProject
    {
        Task<bool> IsCodeUnique(string email, CancellationToken cancellationToken);

        Task<bool> IsTitleUnique(string username, CancellationToken cancellationToken);
    }
}