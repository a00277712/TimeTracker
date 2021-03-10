using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public class ProjectCloseoutService : IProjectCloseoutService
    {
        private readonly HttpClient http;

        public ProjectCloseoutService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task Create(ProjectCloseoutDto dto)
        {
            await http.PostAsJsonAsync("api/project/closeout/create", dto);
        }

        public async Task<ProjectCloseoutVw> GetVwAsync()
        {
            return await http.GetFromJsonAsync<ProjectCloseoutVw>("api/project/closeout/vw");
        }
    }
}
