using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            Time = new HashSet<Time>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public long? TaskNo { get; set; }
        public string Title { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }

        public virtual Projects Project { get; set; }
        public virtual ICollection<Time> Time { get; set; }
    }
}
