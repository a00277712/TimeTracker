using System;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models
{
    public class ProjectDto
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string OldCode { get; set; }
        public string Title { get; set; }
        public string OldTitle { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string ClientContact { get; set; }
        public string Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CommercialCover { get; set; }
        public string ProjectDeliverables { get; set; }
        public bool? DataProcessing { get; set; }
        public int? BudgetDays { get; set; }
        public string ProjectManagerId { get; set; }
        public string ContactEmail { get; set; }
        public int? ReferenceProcesses { get; set; }
        public bool? Deleted { get; set; }
        public string ProjectTemplate { get; set; }
    }
}
