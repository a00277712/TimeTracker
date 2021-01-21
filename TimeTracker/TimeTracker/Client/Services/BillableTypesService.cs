using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public class BillableTypesService : IBillableTypeService
    {
        private readonly HttpClient http;

        public BillableTypesService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<BillableTypeDto[]> Get()
        {
            return await http.GetFromJsonAsync<BillableTypeDto[]>($"api/billable-types");
        }
    }
}
