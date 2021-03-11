using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models.Reports
{
    public class MonthSummaryParams
    {
        [Required]
        [Range(1, 12)]
        public int Month { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
