using System;

namespace TimeTracker.Shared.Models
{
    public class HoursEnteredParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }
        public string ProjectTitle { get; set; }
    }
}
