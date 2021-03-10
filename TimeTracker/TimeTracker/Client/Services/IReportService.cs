using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Shared.Models;

namespace TimeTracker.Client.Services
{
    public interface IReportService
    {
        public Task<HttpResponseMessage> GetHoursEntered(HoursEnteredParams para);
        public Task<HttpResponseMessage> GetMonthSummaryByUser(MonthSummaryParams para);
        public Task<HttpResponseMessage> GetMonthSummaryByWeek(MonthSummaryParams para);
    }
}
