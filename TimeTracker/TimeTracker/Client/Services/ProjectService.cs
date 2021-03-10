using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeTracker.Client.Models;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient http;

        public ProjectService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task Create(ProjectDto dto)
        {
            await http.PostAsJsonAsync("api/projects/create", dto);
        }

        public async Task Delete(int id)
        {
            await http.DeleteAsync($"api/projects/delete/{id}");
        }

        public async Task Edit(ProjectDto dto)
        {
            await http.PostAsJsonAsync("api/projects/edit", dto);
        }

        public async Task<ProjectDto[]> Get()
        {
            return await http.GetFromJsonAsync<ProjectDto[]>("api/projects");
        }

        public async Task<ProjectDto> GetById(int id)
        {
            return await http.GetFromJsonAsync<ProjectDto>($"api/projects/{id}");
        }

        public async Task<ProjectDashboardDto[]> GetProjectDashboard()
        {
            return await http.GetFromJsonAsync<ProjectDashboardDto[]>($"api/projects/dashboard");
        }

        public async Task<ProjectLogHistoryDto[]> GetProjectDashboardHistory(int Id)
        {
            return await http.GetFromJsonAsync<ProjectLogHistoryDto[]>($"api/projects/dashboard/history/" + Id);
        }

        public async Task<VwTimeProjectUserDto[]> GetProjectDashboardSummary(int Id)
        {
            return await http.GetFromJsonAsync<VwTimeProjectUserDto[]>($"api/projects/dashboard/summary/" + Id);
        }

        public async Task<string[]> GetProjectTemplates()
        {
            return await http.GetFromJsonAsync<string[]>($"api/projects/templates");
        }

        public async Task UpdateProjectLog(ProjectLogDto dto)
        {
            await http.PostAsJsonAsync("api/projects/log/update", dto);
        }
    }
}
