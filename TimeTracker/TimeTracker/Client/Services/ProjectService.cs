using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
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

        public async Task<ProjectDto> GetById(string id)
        {
            return await http.GetFromJsonAsync<ProjectDto>($"api/projects/{id}");
        }

        public async Task<string[]> GetProjectTemplates()
        {
            return await http.GetFromJsonAsync<string[]>($"api/projects/templates");
        }
    }
}
