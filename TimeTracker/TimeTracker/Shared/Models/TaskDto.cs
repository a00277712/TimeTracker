using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public long? TaskNo { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
