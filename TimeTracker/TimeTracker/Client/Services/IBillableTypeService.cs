using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    interface IBillableTypeService
    {
        public Task<BillableTypeDto[]> Get();
    }
}
