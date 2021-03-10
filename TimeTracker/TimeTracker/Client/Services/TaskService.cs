using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient http;

        public TaskService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task Create(TaskDto dto)
        {
            await http.PostAsJsonAsync("api/project/task/create", dto);
        }

        public async Task Delete(int id)
        {
            await http.DeleteAsync($"api/project/task/delete/{id}");
        }

        public async Task Edit(TaskDto dto)
        {
            await http.PostAsJsonAsync("api/project/task/edit", dto);
        }

        public async Task<TaskDto[]> Get()
        {
            return await http.GetFromJsonAsync<TaskDto[]>("api/project/task");
        }

        public async Task<TaskDto> GetById(int id)
        {
            return await http.GetFromJsonAsync<TaskDto>($"api/project/task/{id}");
        }

        public async Task<TaskDto[]> GetByProjectId(string projectId)
        {
            return await http.GetFromJsonAsync<TaskDto[]>($"api/project/tasks/{projectId}");
        }
    }
}
