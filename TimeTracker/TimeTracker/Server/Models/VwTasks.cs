using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class VwTasks
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public long? TaskNo { get; set; }
        public string Title { get; set; }
        public decimal SpentDays { get; set; }
        public string DisplayText { get; set; }
    }
}
