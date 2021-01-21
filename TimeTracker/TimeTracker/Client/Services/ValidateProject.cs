using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TimeTracker.Client.Services
{
    public class ValidateProject : IValidateProject
    {
        private readonly HttpClient http;

        public ValidateProject(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<bool> IsCodeUnique(string code, CancellationToken token)
        {
            if (code == null || code.Length == 0)
            {
                return true;
            }
            else
            {
                return await http.GetFromJsonAsync<bool>($"api/projects/unique/code/{code}", token);
            }
        }

        public async Task<bool> IsTitleUnique(string title, CancellationToken token)
        {
            if (title == null || title.Length == 0)
            {
                return true;
            }
            else
            {
                return await http.GetFromJsonAsync<bool>($"api/projects/unique/title/{title}", token);
            }
        }
    }
}
