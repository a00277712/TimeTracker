using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TimeTracker.Client.Services
{
    public class ValidateUser : IValidateUser
    {
        private readonly HttpClient http;

        public ValidateUser(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<bool> IsEmailUnique(string email, CancellationToken token)
        {
            if (email == null || email.Length == 0)
            {
                return true;
            }
            else
            {
                return await http.GetFromJsonAsync<bool>($"api/users/unique/email/{email}", token);
            }
        }

        public async Task<bool> IsUsernameUnique(string username, CancellationToken token)
        {
            if (username == null || username.Length == 0)
            {
                return true;
            }
            else
            {
                return await http.GetFromJsonAsync<bool>($"api/users/unique/username/{username}", token);
            }
        }
    }
}
