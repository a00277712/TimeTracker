using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class Projects
    {
        public Projects()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string ClientContact { get; set; }
        public string Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CommercialCover { get; set; }
        public string ProjectDeliverables { get; set; }
        public bool? DataProcessing { get; set; }
        public int? BudgetDays { get; set; }
        public string ProjectManagerId { get; set; }
        public string ContactEmail { get; set; }
        public int? ReferenceProcesses { get; set; }
        public string CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool Deleted { get; set; }

        public virtual ProjectCloseouts ProjectCloseouts { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
