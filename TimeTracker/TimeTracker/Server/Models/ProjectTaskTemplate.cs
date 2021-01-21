using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class ProjectTaskTemplate
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public int TaskNo { get; set; }
        public string ProjectType { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }
    }
}
