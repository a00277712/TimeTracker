using System;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models.Reports
{
    public class ProjectCloseoutsParams
    {
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public string Client { get; set; }
        public string ProjectTitle { get; set; }
    }
}
