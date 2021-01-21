using System;
using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    interface ITimeService : ICRUDService<TimeDto>
    {
        public Task<HttpResponseMessage> GetByDate(DateTime date);
    }
}
