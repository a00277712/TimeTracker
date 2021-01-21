using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class VwTime
    {
        public int Id { get; set; }
        public DateTime WorkDate { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public decimal Hours { get; set; }
        public string UserId { get; set; }
        public string TaskTitle { get; set; }
        public string ProjectTitle { get; set; }
        public string Billable { get; set; }
    }
}
