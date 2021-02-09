using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class ProjectLog
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedById { get; set; }

        public virtual AspNetUsers CreatedBy { get; set; }
        public virtual Projects Project { get; set; }
    }
}
