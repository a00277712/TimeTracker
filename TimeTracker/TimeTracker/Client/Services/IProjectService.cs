using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    interface IProjectService: ICRUDService<ProjectDto>
    {
        public Task<string[]> GetProjectTemplates();
    }
}
