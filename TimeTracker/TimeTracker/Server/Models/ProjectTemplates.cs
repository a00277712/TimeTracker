using System;
using System.Collections.Generic;

namespace TimeTracker.Server.Models
{
    public partial class ProjectTemplates
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public int TaskNo { get; set; }
        public string ProjectType { get; set; }
    }
}
