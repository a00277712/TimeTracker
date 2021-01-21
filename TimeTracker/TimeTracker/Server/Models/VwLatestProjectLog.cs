using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class VwLatestProjectLog
    {
        public int ProjectId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Text { get; set; }
    }
}
