using System;

namespace TimeTracker.Shared.Models
{
    public class BillableTypeDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }
    }
}
