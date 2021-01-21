using System;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models
{
    public class TimeDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TaskId { get; set; }
        [Required]
        public DateTime WorkDate { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Hours { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Comment { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Location { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select a Billable type")]
        public int BillableTypeId { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }
    }
}
