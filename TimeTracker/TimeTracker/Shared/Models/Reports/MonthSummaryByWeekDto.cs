namespace TimeTracker.Shared.Models
{
    public class MonthSummaryByWeekDto
    {
        public string Customer { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectTitle { get; set; }
        public int? ReferenceProcesses { get; set; }
        public decimal? Week1 { get; set; }
        public decimal? Week2 { get; set; }
        public decimal? Week3 { get; set; }
        public decimal? Week4 { get; set; }
        public decimal? Week5 { get; set; }
        public decimal? Week6 { get; set; }
        public decimal? TotalHours { get; set; }
    }
}
