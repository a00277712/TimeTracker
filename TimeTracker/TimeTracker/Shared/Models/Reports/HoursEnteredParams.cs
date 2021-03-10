using System;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models
{
    public class HoursEnteredParams
    {
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }
        public string ProjectTitle { get; set; }
    }
}
