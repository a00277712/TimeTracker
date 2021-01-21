using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    interface ITaskService : ICRUDService<TaskDto>
    {
        public Task<TaskDto[]> GetByProjectId(string Id);
    }
}
