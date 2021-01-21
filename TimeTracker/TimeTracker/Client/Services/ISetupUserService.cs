using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    interface ISetupUserService
    {
        public Task Create(UserDto user);
        public Task Delete(string id);
        public Task Edit(UserDto user);
        public Task<UserDto[]> Get();
        public Task<UserDto> GetById(string id);
        public Task<VwUserRole[]> GetRolesByUserId(string userId);
        public Task SetRole(VwUserRole role);
    }
}
