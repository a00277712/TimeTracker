using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public interface IProjectCloseoutService
    {
        public Task Create(ProjectCloseoutDto dto);
        public Task<ProjectCloseoutVw> GetVwAsync();
    }
}
