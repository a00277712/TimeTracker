using System;

namespace TimeTracker.Shared.Models
{
    public class ProjectDashboardDto
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ProjectLogDate { get; set; }
        public string ProjectLog { get; set; }
        public int? ReferenceProcesses { get; set; }
        public string Lead { get; set; }
    }
}
