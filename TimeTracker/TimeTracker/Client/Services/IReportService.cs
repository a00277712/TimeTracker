using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Shared.Models.Reports;

namespace TimeTracker.Client.Services
{
    public interface IReportService
    {
        public Task<HttpResponseMessage> GetHoursEntered(HoursEnteredParams para);
        public Task<HttpResponseMessage> GetHoursEnteredExcel(HoursEnteredParams para);
        public Task<HttpResponseMessage> GetMonthSummaryByUser(MonthSummaryParams para);
        public Task<HttpResponseMessage> GetMonthSummaryByWeek(MonthSummaryParams para);
        public Task<HttpResponseMessage> GetMonthSummaryExcel(MonthSummaryParams para);
        public Task<HttpResponseMessage> GetProjectCloseouts(ProjectCloseoutsParams para);
        public Task<HttpResponseMessage> GetProjectCloseoutsExcel(ProjectCloseoutsParams para);
    }
}
