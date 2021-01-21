using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    interface IProjectService: ICRUDService<ProjectDto>
    {
        public Task<ProjectDashboardDto[]> GetProjectDashboard();
        public Task<string[]> GetProjectTemplates();
        public Task UpdateProjectLog(ProjectLogDto dto);
    }
}
