using System;

namespace TimeTracker.Shared.Models
{
    public class VwTimeDto
    {
        public int Id { get; set; }
        public DateTime WorkDate { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public decimal Hours { get; set; }
        public string TaskTitle { get; set; }
        public string ProjectTitle { get; set; }
        public string Billable { get; set; }
    }
}
