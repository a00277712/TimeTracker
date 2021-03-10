using System;

namespace TimeTracker.Shared.Models
{
    public class HoursEnteredDto
    {
        public string ProjectCode { get; set; }
        public string ProjectTitle { get; set; }
        public string Client { get; set; }
        public string TaskTitle { get; set; }
        public string UserName { get; set; }
        public DateTime WorkDate { get; set; }
        public float Hours { get; set; }
        public string Comments { get; set; }
        public string BillableType { get; set; }
        public string Location { get; set; }
    }
}
