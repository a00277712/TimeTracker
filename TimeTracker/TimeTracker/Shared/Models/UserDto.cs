using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string OldUsername { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string OldEmail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
