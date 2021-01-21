using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class CloseoutReasons
    {
        public CloseoutReasons()
        {
            ProjectCloseouts = new HashSet<ProjectCloseouts>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ProjectCloseouts> ProjectCloseouts { get; set; }
    }
}
