using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class Time
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TaskId { get; set; }
        public DateTime WorkDate { get; set; }
        public decimal Hours { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public int BillableTypeId { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }

        public virtual BillableType BillableType { get; set; }
        public virtual Tasks Task { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
