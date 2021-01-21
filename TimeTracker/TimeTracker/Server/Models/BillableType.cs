using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class BillableType
    {
        public BillableType()
        {
            Time = new HashSet<Time>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Time> Time { get; set; }
    }
}
