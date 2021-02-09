namespace TimeTracker.Shared.Models
{
    class MonthSummaryByWeekDto
    {
        public string Customer { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectTitle { get; set; }
        public int ReferenceProcesses { get; set; }
        public float Week1 { get; set; }
        public float Week2 { get; set; }
        public float Week3 { get; set; }
        public float Week4 { get; set; }
        public float Week5 { get; set; }
        public float Week6 { get; set; }
        public float Total { get; set; }
    }
}
