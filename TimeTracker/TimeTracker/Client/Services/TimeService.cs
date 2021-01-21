using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public class TimeService : ITimeService
    {
        private readonly HttpClient http;

        public TimeService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task Create(TimeDto dto)
        {
            await http.PostAsJsonAsync("api/time/create", dto);
        }

        public async Task Delete(int id)
        {
            await http.DeleteAsync($"api/time/delete/{id}");
        }

        public async Task Edit(TimeDto dto)
        {
            await http.PostAsJsonAsync("api/time/edit", dto);
        }

        public async Task<TimeDto[]> Get()
        {
            return await http.GetFromJsonAsync<TimeDto[]>("api/time");
        }

        public async Task<HttpResponseMessage> GetByDate(DateTime date)
        {
            return await http.PostAsJsonAsync("api/times/", new DateDto { Date = date });
        }

        public async Task<TimeDto> GetById(string id)
        {
            return await http.GetFromJsonAsync<TimeDto>($"api/time/{id}");
        }
    }
}
