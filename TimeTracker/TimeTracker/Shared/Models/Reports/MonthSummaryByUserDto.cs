namespace TimeTracker.Shared.Models
{
    public class MonthSummaryByUserDto
    {
        public string Customer { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectTitle { get; set; }
        public int ReferenceProcesses { get; set; }
        public string UserName { get; set; }
        public float Hours { get; set; }
    }
}
