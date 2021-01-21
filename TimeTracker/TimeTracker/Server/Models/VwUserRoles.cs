using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class VwUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? Assigned { get; set; }
    }
}
