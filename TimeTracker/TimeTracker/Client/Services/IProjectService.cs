using System.Threading.Tasks;
using TimeTracker.Client.Models;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    interface IProjectService: ICRUDService<ProjectDto>
    {
        public Task<ProjectDashboardDto[]> GetProjectDashboard();
        public Task<ProjectLogHistoryDto[]> GetProjectDashboardHistory(int Id);
        public Task<VwTimeProjectUserDto[]> GetProjectDashboardSummary(int Id);
        public Task<string[]> GetProjectTemplates();
        public Task UpdateProjectLog(ProjectLogDto dto);
        public Task<ProjectDto[]> GetActive();
    }
}
