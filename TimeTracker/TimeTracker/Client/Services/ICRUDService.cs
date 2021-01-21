using System.Threading.Tasks;

namespace TimeTracker.Client.Services
{
    interface ICRUDService<T>
    {
        public Task Create(T user);
        public Task Delete(int id);
        public Task Edit(T user);
        public Task<T[]> Get();
        public Task<T> GetById(string id);
    }
}
