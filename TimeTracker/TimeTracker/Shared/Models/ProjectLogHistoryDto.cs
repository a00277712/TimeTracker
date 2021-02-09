using System;

namespace TimeTracker.Shared.Models
{
    public class ProjectLogHistoryDto
    {
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
