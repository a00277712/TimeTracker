using System;

namespace TimeTracker.Shared.Models
{
    public class ProjectLogDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedById { get; set; }
    }
}
