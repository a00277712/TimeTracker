using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public class SetupUsersService : ISetupUserService
    {
        private readonly HttpClient http;

        public SetupUsersService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task Create(UserDto user)
        {
            await http.PostAsJsonAsync("api/users/create", user);
        }

        public async Task Delete(string id)
        {
            await http.DeleteAsync($"api/users/delete/{id}");
        }

        public async Task Edit(UserDto user)
        {
            await http.PostAsJsonAsync("api/users/edit", user);
        }

        public async Task<UserDto[]> Get()
        {
            return await http.GetFromJsonAsync<UserDto[]>("api/users");
        }

        public async Task<UserDto> GetById(string id)
        {
            return await http.GetFromJsonAsync<UserDto>($"api/users/{id}");
        }

        public async Task<VwUserRole[]> GetRolesByUserId(string userId)
        {
            return await http.GetFromJsonAsync<VwUserRole[]>($"api/roles/{userId}");
        }

        public async Task SetRole(VwUserRole role)
        {
            await http.PostAsJsonAsync("api/roles/set", role);
        }
    }
}
