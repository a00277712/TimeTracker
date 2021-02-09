using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class VwHoursEntered
    {
        public int? Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectTitle { get; set; }
        public string Client { get; set; }
        public long TaskNo { get; set; }
        public string TaskTitle { get; set; }
        public string Username { get; set; }
        public DateTime WorkDate { get; set; }
        public decimal Hours { get; set; }
        public decimal Days { get; set; }
        public string Comments { get; set; }
        public string Location { get; set; }
        public string BillableType { get; set; }
    }
}
