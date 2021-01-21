namespace TimeTracker.Shared.Models
{
    public class VwUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? Assigned { get; set; }
    }
}
