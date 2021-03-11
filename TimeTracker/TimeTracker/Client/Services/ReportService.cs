using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeTracker.Shared.Models.Reports;

namespace TimeTracker.Client.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient http;

        public ReportService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<HttpResponseMessage> GetHoursEntered(HoursEnteredParams para)
        {
            return await http.PostAsJsonAsync("api/reports/hours-entered", para);
        }

        public async Task<HttpResponseMessage> GetMonthSummaryByUser(MonthSummaryParams para)
        {
            return await http.PostAsJsonAsync("api/reports/month-summary/user", para);
        }

        public async Task<HttpResponseMessage> GetMonthSummaryByWeek(MonthSummaryParams para)
        {
            return await http.PostAsJsonAsync("api/reports/month-summary/week", para);
        }

        public async Task<HttpResponseMessage> GetProjectCloseouts(ProjectCloseoutsParams para)
        {
            return await http.PostAsJsonAsync("api/reports/project-closeouts", para);
        }
    }
}
